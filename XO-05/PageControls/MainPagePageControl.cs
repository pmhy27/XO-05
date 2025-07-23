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
    public partial class MainPagePageControl : UserControl,IpageLifecycle
    {
        public List<PlcMappingInfo> UnitsTable{ get; private set; }
        PageTools pageTools = new PageTools();
  


        public MainPagePageControl()
        {
            InitializeComponent();
            UnitsTable = new List<PlcMappingInfo>();
            InitilizeLampDataMappings();


        }

        public void InitilizeLampDataMappings()
        {
            
            UnitsTable.Add(new PlcMappingInfo { UIControl = lampButton_Inline, DeviceType = "L", Address = 1200 });
            UnitsTable.Add(new PlcMappingInfo { UIControl = lampButton_Offline, DeviceType = "L", Address = 1201 });
            UnitsTable.Add(new PlcMappingInfo { UIControl = lampButton_HeaterOn, DeviceType = "L", Address = 1202 });
            UnitsTable.Add(new PlcMappingInfo { UIControl = lampButton_HeaterOff, DeviceType = "L", Address = 1203 });
            UnitsTable.Add(new PlcMappingInfo { UIControl = lampButton_CycleStopOn, DeviceType = "L", Address = 1204 });
            UnitsTable.Add(new PlcMappingInfo { UIControl = lampButton_CycleStopOff, DeviceType = "L", Address = 1205 });         
        }


        public void OnPageVisible()
        {
           
        }

        public void OnPageHidden()
        {
            
        }

    }

}
