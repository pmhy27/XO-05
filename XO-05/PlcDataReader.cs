using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MELSECNETH_Lib;

namespace XO_05
{
    public class PlcReadBlock
    {
        #region
        Dictionary<string, short> DeviceTypeTable = new Dictionary<string, short>()
        {
            {"X",1},
            {"Y",2},
            {"L",3},
            {"M",4},
            {"D",13},
            {"R",22},
            {"ZR",220},
            {"B",23},
            {"W",24}
        };

        #endregion 
        //DeviceTypeTable

        #region
        private string _deviceType; //元件類型，例如 D、M、R...
        public string DeviceType
        {
            get { return _deviceType; }
            set { _deviceType = value; }
        }

        private int _startAddress;//元件起始位置
        public int StartAddress
        {
            get { return _startAddress; }
            set { _startAddress = value; }
        }


        private int _pointsToRead;  //要讀取的元件數目
        public int PointsToRead
        {
            get { return _pointsToRead; }
            set { _pointsToRead = value; }
        }

        private short _deviceTypeInMDFUNC32; //PLC記憶體類型的在NET/H通訊LIBRARY裡代號
        public short DeviceTypeInMDFUNC32
        {
            get { return _deviceTypeInMDFUNC32; }
            set { }
        }
        #endregion
        //Properties

        public PlcReadBlock(string deviceType, int startAddress, int pointsToRead)
	    {
            _deviceType = deviceType;
            _startAddress = startAddress;
            _pointsToRead = pointsToRead;
            DeviceTypeToDeviceTypeInMDFUNC32(deviceType);
	    }

        

        //PLC記憶體類型查表，見手冊SH081035 章節4.2.4
        private void DeviceTypeToDeviceTypeInMDFUNC32(string deviceType)
        {
            short code;
            if (DeviceTypeTable.TryGetValue(deviceType, out code))
            {
                _deviceTypeInMDFUNC32 = code;
            }
            else
            {
                throw new ArgumentException("DeviceTypeToDeviceTypeInMDFUNC32 尚不支援此plc元件");
            }
        }

    }


    public class PlcDataReader_NetH
    {



        /// <summary>
        /// 執行一次性批次隨機讀取
        /// </summary>
        /// <param name="readBlocks">一個包含多個區塊的列表</param>
        /// <returns>一個包含所有讀回資料的字典，KEY = "裝置類型"+"起始位置"</returns>
        public short[] ReadData(List<PlcReadBlock> readBlocks)
        {
            if (!PlcConnectionManager.NetHConnection.IsConnected || readBlocks == null || readBlocks.Count == 0)
            {
                return null;
            }

            //建立一個Array存放所有要問PLC的記憶體位置，
            //格式為：區塊總數,第一個要問的位置區段的DeviceType,第一個要問的位置區段的startAddress,連續要問的數目,第二個要問的位置區段的.....
            int[] devArray = new int[1 + readBlocks.Count*3 ];
            devArray[0] = readBlocks.Count;

            int totalPoints = 0;

            for (int i = 0; i < readBlocks.Count; i++)
            {
                var block = readBlocks[i];
                devArray[1 + i * 3] = block.DeviceTypeInMDFUNC32;
                devArray[2 + i * 3] = block.StartAddress;
                devArray[3 + i * 3] = block.PointsToRead;

                if (PlcMappingInfo.isBitType(block.DeviceType))
                {
                    totalPoints += 1;
                }
                else
                {
                    totalPoints += block.PointsToRead;                
                }
            }

            //準備一個足夠大的緩衝區
            short[] dataBuffer = new short[totalPoints];
            int bufferSizeInByte = totalPoints * 2; // 1 short = 2bytes

            //執行隨機讀取命令
            int result = MDFUNC32.mdRandREx(
                PlcConnectionManager.NetHConnection._connectingPath,
                PlcConnectionManager.NetHConnection.NetworkNo,
                PlcConnectionManager.NetHConnection.StationNo,
                ref devArray[0],
                ref dataBuffer[0],
                bufferSizeInByte

                );

            //讀取失敗拋回錯誤碼
            if (result != 0)
            {
                throw new Exception("PL隨機讀取(CmdRandREx)失敗，錯誤碼：" + result);
            }


            ////讀取成功，將結果從array編成dictionary方便使用
            //Dictionary<string, short[]> resultMap = new Dictionary<string,short[]>();
            //int bufferIndex = 0;

            ////將讀出來的buffer拆解成小塊
            //foreach(var block in readBlocks)
            //{
            //    short[] blockData = new short[block.PointsToRead];
            //    Array.Copy(dataBuffer, bufferIndex, blockData, 0, block.PointsToRead);

            ////用裝置類型"+"起始位置"當KEY，上面拆出來的ARRAY[]當VALUE
            //    string key = string.Format("{0}{1}", block.DeviceType, block.StartAddress);
            //    resultMap.Add(key, blockData);

            //    bufferIndex += block.PointsToRead;            
            //}

            return dataBuffer;
        }








    }





}
