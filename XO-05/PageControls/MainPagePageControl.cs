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
        private List<PlcMappingInfo> _dataMappingTable;
        //private List<PlcReadBlock> _plcReadBlock;
        PageTools pageTools = new PageTools();
        Dictionary<string, byte[]> _resultsMappingTable;


        public MainPagePageControl()
        {
            InitializeComponent();
            InitilizeLampDataMappings();


        }

        public void InitilizeLampDataMappings()
        {
            _dataMappingTable = new List<PlcMappingInfo>();
            _dataMappingTable.Add(new PlcMappingInfo { UIControl = lampButton_Inline, DeviceType = "L", address = 1200 });
            _dataMappingTable.Add(new PlcMappingInfo { UIControl = lampButton_Offline, DeviceType = "L", address = 1201 });
            _dataMappingTable.Add(new PlcMappingInfo { UIControl = lampButton_HeaterOn, DeviceType = "L", address = 1202 });
            _dataMappingTable.Add(new PlcMappingInfo { UIControl = lampButton_HeaterOff, DeviceType = "L", address = 1203 });
            _dataMappingTable.Add(new PlcMappingInfo { UIControl = lampButton_CycleStopOn, DeviceType = "L", address = 1204 });
            _dataMappingTable.Add(new PlcMappingInfo { UIControl = lampButton_CycleStopOff, DeviceType = "L", address = 1205 });         
        }


        public void OnPageVisible()
        {
            throw new NotImplementedException();
        }

        public void OnPageHidden()
        {
            throw new NotImplementedException();
        }


        public List<PlcReadBlock> GetPlcReadRequests(out Dictionary<string, byte[]> resultsMappingTable)
        {

            return pageTools.CreateReadBlocks(_dataMappingTable, out resultsMappingTable);
 
        }

        void UpdateUi(Dictionary<string, short[]> plcdata)
        {
            ;
        }
    }

}
