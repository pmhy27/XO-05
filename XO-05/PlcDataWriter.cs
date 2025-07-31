using System;
using System.Collections.Generic;
using MELSECNETH_Lib;
using System.Collections.Concurrent;
using System.Threading;   // 你已經在 PlcDataReader 用了這個 DLL

namespace XO_05
{
    public class PlcWriteBlock
    {
        #region DeviceType 對應表（同 PlcReadBlock）
        private static readonly Dictionary<string, short> DeviceTypeTable = new Dictionary<string, short>(StringComparer.OrdinalIgnoreCase)
        {
            {"X",1}, {"Y",2}, {"L",3}, {"M",4}, {"S",5}, {"F",6}, {"T",7}, {"C",9}, {"D",10}, {"R",11},
            {"Z",12}, {"V",13}, {"K",14}, {"A",15}, {"B",16}, {"W",24}
        };
        #endregion

        /// <summary>裝置類型，例如 D、M、R…</summary>
        public string DeviceType { get; private set; }
        /// <summary>起始位址</summary>
        public int StartAddress { get; private set; }
        /// <summary>要寫入的資料（以 word 為單位）。若是位元型別，會先被打包成 1 個 short 放在這裡。</summary>
        public short[] DataToWrite { get; private set; }
        /// <summary>對應 MDFUNC32 的裝置代碼</summary>
        public short DeviceTypeInMDFUNC32 { get; private set; }
        /// <summary>實際要寫入的 word 數量（bit 型別固定為 1）</summary>
        public int PointsToWrite { get; private set; }

        /// <summary>
        /// 建立 word 型別的寫入區塊（D、W、R…）
        /// </summary>
        public PlcWriteBlock(string deviceType, int startAddress, short[] dataWords)
        {
            if (dataWords == null || dataWords.Length == 0)
                throw new ArgumentException("dataWords 不可為空。");

            DeviceType = deviceType;
            StartAddress = startAddress;
            DataToWrite = dataWords;
            PointsToWrite = dataWords.Length;
            DeviceTypeInMDFUNC32 = ToMdfunc32Code(deviceType);
        }

        /// <summary>
        /// 建立 bit 型別的寫入區塊（X、Y、M、L、B）。會將 bool[] 先打包成 1 個 short。
        /// 最多支援 16 個 bit，一次一個 word。
        /// </summary>
        public static PlcWriteBlock FromBits(string deviceType, int startAddress, bool[] bits)
        {
            if (bits == null || bits.Length == 0)
                throw new ArgumentException("bits 不可為空。");

            if (!PlcMappingInfo.isBitType(deviceType))
                throw new ArgumentException("DeviceType 不是 bit 型別。");

            if (bits.Length > 16)
                throw new ArgumentException("一次只能打包 16 個 bit，請自行切段。");

            short packed = PackBits(bits);
            return new PlcWriteBlock(deviceType, startAddress, new[] { packed });
        }

        private static short PackBits(bool[] bits)
        {
            int value = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i]) value |= (1 << i);
            }
            return (short)value;
        }

        private static short ToMdfunc32Code(string deviceType)
        {
            short code;
            if (!DeviceTypeTable.TryGetValue(deviceType, out code))
                throw new ArgumentException("未知的裝置類型: " + deviceType);
            return code;
        }
    }


    /// <summary>
    /// 封裝一次 PLC 寫入請求。為了彈性，直接用 List<PlcWriteBlock>。
    /// </summary>
    public class PlcWriteCommand
    {
        public List<PlcWriteBlock> Blocks { get; private set; }
        /// <summary>可選：執行完畢後要回呼的委派。bool=成功/失敗, Exception=失敗原因</summary>
        public Action<bool, Exception> Callback { get; private set; }
        /// <summary>排隊時間，可用於除錯或統計</summary>
        public DateTime EnqueueTime { get; private set; }
        /// <summary>可選：優先權（目前未使用，預留）</summary>
        public int Priority { get; private set; }

        public PlcWriteCommand(List<PlcWriteBlock> blocks, Action<bool, Exception> callback = null, int priority = 0)
        {
            if (blocks == null || blocks.Count == 0)
                throw new ArgumentException("blocks 不可為空");
            Blocks = blocks;
            Callback = callback;
            Priority = priority;
            EnqueueTime = DateTime.Now;
        }
    }

    /// <summary>
    /// 單例寫入服務。背景執行緒阻塞等待，收到命令後呼叫 PlcDataWriter_NetH 進行實際寫入。
    /// </summary>
    public sealed class PlcWriteService : IDisposable
    {
        public static readonly PlcWriteService Instance = new PlcWriteService();

        private readonly BlockingCollection<PlcWriteCommand> _queue;
        private readonly Thread _worker;
        private readonly PlcDataWriter_NetH _writer;
        private volatile bool _disposed;

        private PlcWriteService()
        {
            _queue = new BlockingCollection<PlcWriteCommand>(new ConcurrentQueue<PlcWriteCommand>());
            _writer = new PlcDataWriter_NetH();

            _worker = new Thread(WorkerLoop)
            {
                IsBackground = true,
                Name = "PlcWriteServiceWorker"
            };
            _worker.Start();
        }

        /// <summary>
        /// 佇列新增一筆寫入命令。
        /// </summary>
        public void Enqueue(PlcWriteCommand cmd)
        {
            if (_disposed) throw new ObjectDisposedException("PlcWriteService");
            _queue.Add(cmd);
        }

        private void WorkerLoop()
        {
            foreach (var cmd in _queue.GetConsumingEnumerable())
            {
                try
                {
                    _writer.WriteData(cmd.Blocks);
                    if (cmd.Callback != null) cmd.Callback(true, null);
                }
                catch (Exception ex)
                {
                    if (cmd.Callback != null) cmd.Callback(false, ex);
                }
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _queue.CompleteAdding();
            // 最多等 2 秒讓執行緒自然結束
            if (!_worker.Join(2000))
            {
                try { _worker.Abort(); }
                catch { }
            }
        }
    }





    /// <summary>
    /// 單一寫入區塊的描述，仿照 PlcReadBlock，但加入實際要寫入的資料。
    /// </summary>



    /// <summary>
    /// 寫入端，介面設計仿造 PlcDataReader_NetH。
    /// 使用 MDFUNC32.mdRandWEx 執行隨機批次寫入。
    /// </summary>
    public class PlcDataWriter_NetH
    {
        /// <summary>
        /// 一次性批次隨機寫入。
        /// </summary>
        /// <param name="writeBlocks">要寫入的區塊集合。</param>
        public void WriteData(List<PlcWriteBlock> writeBlocks)
        {
            if (writeBlocks == null || writeBlocks.Count == 0)
                throw new ArgumentException("writeBlocks 不可為空。");

            if (PlcConnectionManager.NetHConnetion == null || !PlcConnectionManager.NetHConnetion.IsConnected)
                throw new InvalidOperationException("尚未連線 PLC。");

            // 建 devArray：第一個元素是區塊數；後面依序 [devType, startAddr, points]
            int[] devArray = new int[1 + writeBlocks.Count * 3];
            devArray[0] = writeBlocks.Count;

            int totalPoints = 0; // word 數
            for (int i = 0; i < writeBlocks.Count; i++)
            {
                PlcWriteBlock blk = writeBlocks[i];
                devArray[1 + i * 3] = blk.DeviceTypeInMDFUNC32;
                devArray[2 + i * 3] = blk.StartAddress;
                devArray[3 + i * 3] = blk.PointsToWrite;

                totalPoints += blk.PointsToWrite;
            }

            // 將所有 DataToWrite 串成一個 buffer（以 short 為單位）
            short[] dataBuffer = new short[totalPoints];
            int idx = 0;
            foreach (PlcWriteBlock blk in writeBlocks)
            {
                Array.Copy(blk.DataToWrite, 0, dataBuffer, idx, blk.DataToWrite.Length);
                idx += blk.DataToWrite.Length;
            }

            int bufferSizeInByte = totalPoints * 2; // 1 short = 2 bytes

            int result = MDFUNC32.mdRandWEx(
                PlcConnectionManager.NetHConnetion._connectingPath,
                PlcConnectionManager.NetHConnetion.NetworkNo,
                PlcConnectionManager.NetHConnetion.StationNo,
                ref devArray[0],
                ref dataBuffer[0],
                bufferSizeInByte);

            if (result != 0)
            {
                throw new Exception("PLC 隨機寫入 (mdRandWEx) 失敗，錯誤碼：" + result);
            }
        }

        /// <summary>
        /// 便利函式：寫入單一 word。
        /// </summary>
        public void WriteWord(string deviceType, int address, short value)
        {
            var blk = new PlcWriteBlock(deviceType, address, new[] { value });
            WriteData(new List<PlcWriteBlock> { blk });
        }

        /// <summary>
        /// 便利函式：寫入 bit（X/Y/M/L/B）。true=ON, false=OFF
        /// </summary>
        public void WriteBits(string deviceType, int startAddress, bool[] bits)
        {
            var blk = PlcWriteBlock.FromBits(deviceType, startAddress, bits);
            WriteData(new List<PlcWriteBlock> { blk });
        }
    }
}
