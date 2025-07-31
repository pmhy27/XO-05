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


        private readonly PageList _pageManager = new PageList();
        //下面兩個基本上是同一個東西，分開只是為了架構上分開意圖和不需頻繁轉型
        private Page _currentPage = null; //紀錄實現了介面的當前頁面
        private UserControl _currentPageControl = null; //紀錄當前的User Control
        private List<PlcReadBlock> _plcReadRequestsTable;

        private PageTools pageTools = new PageTools();
        private PlcDataReader_NetH _plcDataReader_NetH = new PlcDataReader_NetH();
        private short[] RowDataArrayFromPlc;




      

        public Main()
        {


            InitializeComponent();

            this.Load += MainForm_Load;



            // 訂閱導航按鈕面板的事件，傳遞頁面識別符
            navigationButtonsPanel1.PageRequested += NavigationButtonsPanel_PageRequested;
            dataWorker.DoWork += new DoWorkEventHandler(dataWorker_DoWork);
            dataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dataWorker_RunWorkerCompleted);
            dataWorker.WorkerSupportsCancellation = true;
            PollingTimer.Interval = consta
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
            //SwitchPage("TempMonitorPage"); // 預設顯示主頁面




            // ... 訂閱連線狀態變更通知 ...
            PlcConnectionManager.PLCConnection_NetH.ConnectionStatusChanged += OnInitialPlcConnectionStatusChanged;

            // 程式一啟動就進行連線
            PlcConnectionManager.Initialize(1, 1); // 使用預設值
            PlcConnectionManager.NetHConnection.StartConnectionAsync();

            //GetPlcReadRequests();
        }




        void PollingTimer_Tick(object sender, EventArgs e)
        {
            PollingTimer.Stop();

            try
            {
                if (_currentPage != null && !dataWorker.IsBusy)
                {

                    if (_plcReadRequestsTable != null && _plcReadRequestsTable.Count > 0)
                    {
                        dataWorker.RunWorkerAsync(_plcReadRequestsTable);
                    }
                    else
                    {
                        PollingTimer.Start();
                    }
                }
            }
            finally
            {
                PollingTimer.Start();
            }
        }



        void dataWorker_DoWork(object sender, DoWorkEventArgs e)
        
        {
            var worker = (BackgroundWorker)sender;
            var requests = (List<PlcReadBlock>)e.Argument;
            if (worker.CancellationPending) { e.Cancel = true; return; }

            if (PlcConnectionManager.NetHConnection == null || !PlcConnectionManager.NetHConnection.IsConnected)
            {
                e.Result = new Exception("PLC is not connected");
                return;
            }
      
            try
            {
                GetPlcData();
                OrganizePlcDataTable();
                UpdateUiData();
                
                if (worker.CancellationPending) {e.Cancel = true; return;};
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
                MessageBox.Show("讀取PLC時發生預期外的錯誤:\n" + e.Error.Message);
                return;
            }

            if (e.Result is Exception)
            {
                PollingTimer.Stop();
                var ex = (Exception)e.Result;
                MessageBox.Show("讀取PLC時發生錯誤:/n" + ex.Message);
                return;
            }

            //if (_changedDataList.Count > 0)
            //{
            //    UpdateUi(_changedDataList);
            //    _changedDataList.Clear();
            //    _valueSnapshotOld = _currentPage.ReadPlcBuffersList.ToDictionary(PLCBuffer.MakeKey, b => b.Value);
            //}



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
            Page targetPage; // 先宣告變數

            if (_pageManager.Pages.TryGetValue(pageKey, out targetPage)) // 然後再使用 out 關鍵字
            {
                targetPage.BringToFront();

            }
            else
            {
                // C# 4.0 中不能使用字串內插 (String Interpolation) ($"...")
                // 改用傳統的字串拼接
                MessageBox.Show("Page '" + pageKey + "' not found.", "Page Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            }

            if (targetPage == _currentPageControl) { return; }

            //停止計時器並取消任何正在進行的舊任務
            PollingTimer.Stop();
            if (dataWorker.IsBusy || dataWorker.WorkerSupportsCancellation)
            {
                dataWorker.CancelAsync();
            }

            //通知舊頁面即將被隱藏
            if (_currentPage != null)
            {
                _currentPage.OnPageHidden();
            }

            //切換頁面
            // 將目標頁面帶到最前面顯示
            targetPage.BringToFront();
            _currentPageControl = targetPage;
            _currentPage = targetPage;

            

            if (_currentPage != null)
            {
                _currentPage.OnPageVisible();
                PollingTimer.Start();
            }

            GetPlcReadRequests();

        }


        public void GetPlcReadRequests()
        {
            _plcReadRequestsTable = pageTools.CreateReadBlocks(_currentPage.ReadPlcBuffersList);
        }

        public void GetPlcData()
        {
            RowDataArrayFromPlc = _plcDataReader_NetH.ReadData(_plcReadRequestsTable);
        }

        public void OrganizePlcDataTable()
        {
    
            var buffers = _currentPage.ReadPlcBuffersList;   // 快取，避免多次屬性呼叫
    

            foreach (var unit in buffers)
            {
                short temp;
                if (PLCBuffer.isBitType(unit.DeviceType))
                {
                    temp = (short)((RowDataArrayFromPlc[unit.IndexInResultsArray] >> unit.BitIndexInIndexInResultsArray) & 1);                   
                
                }
                else
                {
                    temp = (short)RowDataArrayFromPlc[unit.IndexInResultsArray];                
                }
                
                if(unit.Value != temp)
                {
                    unit.Value = temp;
                    unit.IsChanged = true;
                }

            }
        }



        public void UpdateUiData()
        {
            var buffers = _currentPage.ReadPlcBuffersList;
            var controls = _currentPage.PlcInteractableControls;

            foreach (var buf in buffers) //Page中有向PLC讀取的device列表中的各個device
            {
                if(buf.IsChanged)//是否某有變化
                {
                    foreach (var usedBy in buf.UsedByList)//有變化的話去逐各讀取那些有用到此plc元件的ui元件
                  {
                      foreach (var buf2 in usedBy.ReadPlcBuffers)//有用到此plc元件的ui元件的總用到plc元件列表(1)
                    {
                        foreach (var control in controls) //逐各掃頁面中的各個元件
                        {
                            foreach (var bufInbufsInControls in control.ReadPlcBuffers)//逐各掃掃頁面中各個元件有用到的plc元件列表中的plc元件(2)
                            {
                                if (PLCBuffer.MakeKey(buf2) == PLCBuffer.MakeKey(bufInbufsInControls))//交叉比對(1)和(2)是否相同
                                {
                                    buf2.Value = buf.Value;
                        
                                }
                            }
                            
                        }
                    }
                  }
                }
            }
        }

            
            


      

        public void UpdateUi(IEnumerable<PLCBuffer> changedItems)
        {

            
        }

       
    
  
    
        private void OnInitialPlcConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
        {
                
        MessageBox.Show(e.Message);

        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            PlcWriteService.Instance.Dispose();
            base.OnFormClosed(e);
        }
    
    }
          
          
}