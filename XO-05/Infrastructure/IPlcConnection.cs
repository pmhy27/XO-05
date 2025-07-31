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
        bool IsConnected { get; }
        void Connect(int networkNo, short stationNo);
        void Disconnected();
        

        ///// <param name="device">Ex:D100</param>
        ///// <param name="lenth">Word數</param>
        //int[] Read(string device, int lenth);

        ///// <param name="device"></param>
        ///// <param name="data">查看手冊</param>
        //void Write(string device, int[] data);
    
    }
}
