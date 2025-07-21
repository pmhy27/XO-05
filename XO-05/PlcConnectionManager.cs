using System;
using System.Windows.Forms;

namespace XO_05
{
    public class PlcConnectionManager
    {
        public bool IsConnected { get; private set; }

        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

        public static readonly PlcConnectionManager PLCConnection_NetH = new PlcConnectionManager();

        public static NetHConnection NetHConnetion { get; private set; }

        // Initialize 方法現在只負責建立物件和訂閱事件
        public static void Initialize(int networkNo, short stationNo)
        {
            // 如果已經存在，先確保舊的連線被關閉
            if (NetHConnetion != null)
            {
                NetHConnetion.EndConnection();
            }

            NetHConnetion = new NetHConnection(networkNo, stationNo);
        }

        public void PublishStatusChanged(object sender, ConnectionStatusEventArgs e)
        {
            if (ConnectionStatusChanged != null)
            {
                ConnectionStatusChanged(sender, e);
            }
        
        }
    }
}