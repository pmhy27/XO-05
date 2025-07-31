using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XO_05.Infrastructure
{   
    /// <summary>
    /// 抽象化的PLC連線介面。
    /// 只負責連線/斷線/單筆讀/單筆寫
    /// 具體的封包、呼叫細節留給實做類別
    /// </summary>
    public interface IPlcConnection :IDisposable
    {
        bool Connect();
        void DisConncect();
        
        bool IsConnected { get; }

        event EventHandler ConnectionStatusChanged;
    }


    public interface IPlcReader
    {
        ushort[] Read(PlcReadBlock[] blocks);
    }


    public interface IPlcWriter : IDisposable
    {
        void EnqueueWrite(PlcWriteCommand cmd);
        event EventHandler<PlcWriteCompleteEventArgs> WriteCompleted;
    }
}
