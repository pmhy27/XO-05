using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XO_05.PageControls
{
    public partial class NavigationButtonsPanel : UserControl
    {
        public class PageRequestedEventArgs : EventArgs
        {
            public string PageKey { get; private set; }

            public PageRequestedEventArgs(string pageKey)
            {
                PageKey = pageKey;
            }
        }

        public event EventHandler<PageRequestedEventArgs> PageRequested;

        public NavigationButtonsPanel()
        {
            InitializeComponent();
        }

        private void button_ChangePage_MainPage_Click(object sender, EventArgs e)
        {
            // 在 C# 4.0 中，事件觸發必須這樣檢查 null
            // 傳統模式：先將事件賦值給一個臨時變數，以防止在檢查和觸發之間事件被取消訂閱 (thread-safe)
            EventHandler<PageRequestedEventArgs> handler = PageRequested;
            if (handler != null)
            {
                handler(this, new PageRequestedEventArgs("MainPage"));
            }
        }

        private void button_ChangePage_TempMonitor_Click(object sender, EventArgs e)
        {
            EventHandler<PageRequestedEventArgs> handler = PageRequested;
            if (handler != null)
            {
                handler(this, new PageRequestedEventArgs("TempMonitorPage"));
            }
        }

        private void button_ChangePage_SkipSetting_Click(object sender, EventArgs e)
        {
            EventHandler<PageRequestedEventArgs> handler = PageRequested;
            if (handler != null)
            {
                handler(this, new PageRequestedEventArgs("SkipSettingPage"));
            }
        }

        private void button_ChangePage_BoardExistence_Click(object sender, EventArgs e)
        {
            EventHandler<PageRequestedEventArgs> handler = PageRequested;
            if (handler != null)
            {
                handler(this, new PageRequestedEventArgs("BoardExistencePage"));
            }

        }

        private void button_ChangePage_SystemRecipeSetting_Click(object sender, EventArgs e)
        {
            EventHandler<PageRequestedEventArgs> handler = PageRequested;
            if (handler != null)
            {
                handler(this, new PageRequestedEventArgs("SystemRecipeSettingPage"));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler<PageRequestedEventArgs> handler = PageRequested;
            if (handler != null)
            {
                handler(this, new PageRequestedEventArgs("SettingPage"));
            }
        }


    }
}