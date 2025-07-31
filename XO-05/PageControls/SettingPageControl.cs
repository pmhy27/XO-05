using System;
using System.Windows.Forms;

namespace XO_05.PageControls
{
    public partial class SettingPageControl : Page
    {
        public SettingPageControl()
        {
            InitializeComponent();
            PlcConnectionManager.PLCConnection_NetH.ConnectionStatusChanged += OnPlcConnectionStatusChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int networkNo = int.Parse(UI_NetworkNo.Text);
            short stationNo = short.Parse(UI_StationNo.Text);

            // 1. 建立或更新連線物件
            PlcConnectionManager.Initialize(networkNo, stationNo);

            // 2. 訂閱連線狀態改變的事件
            //PLCConnectionManager.NetHConnetion.ConnectionStatusChanged += OnPlcConnectionStatusChanged;

            // 3. 呼叫非同步的連線方法，UI 不會被卡住
            PlcConnectionManager.NetHConnetion.StartConnectionAsync();

            button1.Enabled = false;
            button1.Text = "Connecting...";
        }

        // 4. 在事件處理常式中更新 UI
        private void OnPlcConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
        {
            button1.Enabled = true;
            button1.Text = "Connect";

            Lamp_ConnectionStatus.IsOn = e.IsConnected;

        }


    }
}