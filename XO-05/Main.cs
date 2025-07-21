using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XO_05.PageControls; // 確保這個命名空間包含你的 UserControl
using System.Threading;
using MELSECNETH_Lib;



namespace XO_05
{
    public partial class Main : Form
    {


        private readonly PageList _pageManager = PageList.Instance;
        //以下兩個基本上是同一個東西，分開只是為了架構上分開意圖和不需頻繁轉型
        private IpageLifecycle _currentPageLifecycle = null; //紀錄實現了介面的當前頁面
        private UserControl _currentPageControl = null; //紀錄當前的User Control
      

        public Main()
        {


            InitializeComponent();

            this.Load += MainForm_Load;
            // 訂閱導航按鈕面板的事件，傳遞頁面識別符
            navigationButtonsPanel1.PageRequested += NavigationButtonsPanel_PageRequested;
            dataWorker.DoWork += new DoWorkEventHandler(dataWorker_DoWork);
            dataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dataWorker_RunWorkerCompleted);
            PollingTimer.Interval = 2000;
            PollingTimer.Tick += new EventHandler(PollingTimer_Tick);

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //    將所有頁面添加到 panelHost 中，並設定 Dock 屬性
            //    它們都將填滿 panelHost，但只有一個會被 BringToFront
            foreach (var page in _pageManager.Pages.Values)
            {
                page.Dock = DockStyle.Fill;
                if (!panelHost.Controls.Contains(page)) // 確保沒有重複添加
                {
                    panelHost.Controls.Add(page);
                }
            }

            // 設置初始顯示的頁面
            SwitchPage("MainPage"); // 預設顯示主頁面

            // ... 訂閱連線狀態變更通知 ...
            PlcConnectionManager.PLCConnection_NetH.ConnectionStatusChanged += OnInitialPlcConnectionStatusChanged;

            // 程式一啟動就進行連線
            PlcConnectionManager.Initialize(1, 1); // 使用預設值
            PlcConnectionManager.NetHConnetion.StartConnectionAsync();
        }




        void PollingTimer_Tick(object sender, EventArgs e)
        {
            if (_currentPageLifecycle != null && !dataWorker.IsBusy)
            {
                List<PlcReadBlock> request = _currentPageLifecycle.GetPlcReadRequests();
                if (request != null && request.Count > 0)
                {
                    dataWorker.RunWorkerAsync(request);
                }
            }
        }



        void dataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var requests = (List<PlcReadBlock>)e.Argument;
            if (worker.CancellationPending) { e.Cancel = true; return; }

            if (PlcConnectionManager.NetHConnetion == null || !PlcConnectionManager.NetHConnetion.IsConnected)
            {
                e.Result = new Exception("PLC is not connected");
                return;
            }

            var dataReader = new PlcDataReader_NetH();

            try
            {
                Dictionary<string, short[]> results = dataReader.ReadData(requests);
                if (worker.CancellationPending) {e.Cancel = true; return;};
                e.Result = results;
            }
            catch(Exception ex)
            {
                e.Result = ex;
            }
                
        }

        void dataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;

            if (e.Error != null)
            {
                PollingTimer.Stop();
                MessageBox.Show("讀取PLC時發生預期物的錯誤:\n" + e.Error.Message);
                return;
            }

            if (e.Result is Exception)
            {
                PollingTimer.Stop();
                var ex = (Exception)e.Result;
                MessageBox.Show("讀取PLC時發生錯誤:/n" + ex.Message);
                return;
            }

            if (e.Result is Dictionary<string, short[]> && _currentPageLifecycle != null)
            {
                var _plcData = (Dictionary<string, short[]>)e.Result;
                _currentPageLifecycle.UpdateUi(_plcData);
            }

        }








        // 處理導航按鈕面板發出的頁面切換請求
        void NavigationButtonsPanel_PageRequested(object sender, NavigationButtonsPanel.PageRequestedEventArgs e)
        {
            SwitchPage(e.PageKey); // 根據傳來的頁面鍵切換
        }

        // 核心的頁面切換邏輯
        private void SwitchPage(string pageKey)
        {

            // C# 4.0 中，out 參數不能直接在 if 語句中宣告
            UserControl targetPage; // 先宣告變數

            if (_pageManager.Pages.TryGetValue(pageKey, out targetPage)) // 然後再使用 out 關鍵字
            {

                // C# 4.0 中不能使用字串內插 (String Interpolation) ($"...")
                // 改用傳統的字串拼接
                MessageBox.Show("Page '" + pageKey + "' not found.", "Page Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (targetPage == _currentPageControl) { return; }

            //停止計時器並取消任何正在進行的舊任務
            PollingTimer.Stop();
            if (dataWorker.IsBusy)
            {
                dataWorker.CancelAsync();
            }

            //通知舊頁面即將被隱藏
            if (_currentPageLifecycle != null)
            {
                _currentPageLifecycle.OnPageHidden();
            }

            //切換頁面
            // 將目標頁面帶到最前面顯示
            targetPage.BringToFront();
            _currentPageControl = targetPage;
            _currentPageLifecycle = targetPage as IpageLifecycle;

            if (_currentPageLifecycle != null)
            {
                _currentPageLifecycle.OnPageVisible();
                PollingTimer.Start();
            }
        }


         private void OnInitialPlcConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
            {
                
                MessageBox.Show(e.Message);

                // 取消訂閱
                //if (sender is NetHConnection )
                //{

                //    NetHConnection connection = (NetHConnection)sender;
                //    connection.ConnectionStatusChanged -= OnInitialPlcConnectionStatusChanged;
                //}
            }   
 




    }
}