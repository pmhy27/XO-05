using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using MELSECNETH_Lib;
using XO_05.Infrastructure;
using XO_05;

namespace XO_05
{

    public class ConnectionStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; private set; }
        public string Message { get; private set; }

        public ConnectionStatusEventArgs(bool isConnected, string message)
        {
            this.IsConnected = isConnected;
            this.Message = message;
        }
    }

        
    public class NetHConnection : IPlcConnection 
    {



        public int _connectingPath = 0;
        private Thread _monitorThread;
        private volatile bool _stopMonitoring = false;

        // 用來將事件送回 UI 執行緒的同步上下文
        private readonly SynchronizationContext _syncContext;

        public int NetworkNo { get; set; }
        public short StationNo { get; set; }
        public bool IsConnected { get; private set; }
        public bool IsChanelOpen { get; private set; }

        public NetHConnection(int networkNo, short stationNo)
        {
            this.NetworkNo = networkNo;
            this.StationNo = stationNo;

            // 捕捉當前執行緒的同步上下文
            _syncContext = SynchronizationContext.Current;
        }


        #region //Connect(int networkNo, short stationNo),StartConnectionAsync()
        public void Connect(int networkNo, short stationNo)
        {
            StartConnectionAsync();
        }

        // ----- 連線方法 -----
        // 啟動一個背景執行緒來做事，然後立刻返回，不會卡住 UI
        public void StartConnectionAsync()
        {
            // 如果正在連線，就不要重複執行
            if (_monitorThread != null && _monitorThread.IsAlive)
            {
                return;
            }

            // 使用背景執行緒來執行耗時的連線工作
            _monitorThread = new Thread(() =>
            {
                try
                {
                    // 實際的連線邏輯
                    short openResult = MDFUNC32.mdOpen(51, -1, ref _connectingPath);
                    if (openResult != 0 || _connectingPath == 0)
                    {
                        // 連線失敗，透過事件通知 UI
                        RaiseConnectionStatusChanged(false, "通道開啟失敗, 錯誤碼: " + openResult);
                        return;
                    }

                    // 連線成功，透過事件通知 UI
                    this.IsChanelOpen = true;
                    RaiseConnectionStatusChanged(true, "MELSECNET/H 通道開啟成功");

                    // 進入連線狀態的監控迴圈
                    CheckConnectionLoop();
                }
                catch (DllNotFoundException)
                {
                    RaiseConnectionStatusChanged(false, "嚴重錯誤: 找不到 MDFUNC32.dll！");
                }
                catch (Exception ex)
                {
                    RaiseConnectionStatusChanged(false, "連線時發生未預期錯誤: " + ex.Message);
                }
            });
            _monitorThread.IsBackground = true;
            _stopMonitoring = false;
            _monitorThread.Start();
        }
        #endregion

        #region //CheckConnectionLoop()
        // ----- 修改監控迴圈 -----
        private void CheckConnectionLoop()
        {
            while (!_stopMonitoring)
            {
                if (this.IsChanelOpen)
                {
                    short _combinesStationNo = (short)((ushort)this.NetworkNo << 8 | (ushort)this.StationNo);
                    short result = MDFUNC32.mdControl(_connectingPath, _combinesStationNo, 0);

                    if (result != 0)
                    {
                        // 連線中斷，透過事件通知 UI
                        this.IsConnected = false;
                        RaiseConnectionStatusChanged(false, "MELSECNET/H 連線中斷" + result);
                        _stopMonitoring = true; // 停止監控
                    }
                    else
                    {
                        if (this.IsConnected == false)
                        {
                            RaiseConnectionStatusChanged(true, "MELSECNET/H 連線成功");
                        }
                        this.IsConnected = true;

                    }
                }
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region // Disconnected(),Dispose(),EndConnection()
        public void Disconnected()
        {
            Dispose();
        }


        public void Dispose()
        {
            EndConnection();
        }

        public void EndConnection()
        {
            _stopMonitoring = true; // 通知監控執行緒結束
            if (_monitorThread != null && _monitorThread.IsAlive)
            {
                _monitorThread.Join(100); // 等待執行緒結束
            }

            if (_connectingPath != 0)
            {
                MDFUNC32.mdClose(_connectingPath);
                _connectingPath = 0;
            }
            this.IsChanelOpen = false;
            this.IsConnected = false;
        }
        #endregion

        // ----- 新增一個安全觸發事件的方法 -----
        private void RaiseConnectionStatusChanged(bool isConnected, string message)
        {
            // 使用 SynchronizationContext 來確保事件總是在建立它的原始執行緒 (UI 執行緒) 上觸發
            if (_syncContext != null)
            {
                _syncContext.Post(o =>
                {
                    //if (connectionstatuschanged != null)
                    //{
                    //    connectionstatuschanged(this, new connectionstatuseventargs(isconnected, message));
                    //}

                    ConnectionStatusEventArgs args = new ConnectionStatusEventArgs(isConnected, message);

                    PlcConnectionManager.PLCConnection_NetH.PublishStatusChanged(this, args);
                }, null);


            }
        }    
    
    
    }
}


