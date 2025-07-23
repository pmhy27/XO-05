using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XO_05.PageControls;

namespace XO_05
{
    class PageList 
    {

        // 集中管理所有頁面 UserControl 的實例
        public Dictionary<string, UserControl> Pages = new Dictionary<string, UserControl>();


        //    初始化所有頁面 UserControl 的實例，並存儲起來
        //    只在應用程式啟動時創建一次
        MainPagePageControl mainPage = new MainPagePageControl();
        TempMonitorPageControl tempMonitorPage = new TempMonitorPageControl();
        SkipSettingPageControl skipSettingPage = new SkipSettingPageControl();
        BoardExistencePageControl boardExistencePage = new BoardExistencePageControl();
        SystemRecipeSettingPageControl systemRecipeSettingPage = new SystemRecipeSettingPageControl();
        SettingPageControl settingPage = new SettingPageControl();

        public PageList()
        {

            // 將頁面添加到字典中，用一個唯一鍵來識別
            Pages.Add("MainPage", mainPage);
            Pages.Add("TempMonitorPage", tempMonitorPage);
            Pages.Add("SkipSettingPage", skipSettingPage);
            Pages.Add("BoardExistencePage", boardExistencePage);
            Pages.Add("SystemRecipeSettingPage", systemRecipeSettingPage);
            Pages.Add("SettingPage", settingPage);

        }


    }
}
