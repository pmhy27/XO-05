using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XO_05
{
    /// <summary>
    /// HMI元件與plc位置間對應關係設定
    /// </summary>
    public class PlcMappingInfo
    {

        public static bool isBitType(string deviceType)
        {
            
            {
                // 使用 StringComparison.OrdinalIgnoreCase 確保比較时不區分大小寫
                return string.Equals(deviceType, "X", System.StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(deviceType, "Y", System.StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(deviceType, "M", System.StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(deviceType, "L", System.StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(deviceType, "B", System.StringComparison.OrdinalIgnoreCase);
            }
        }


        public PlcMappingInfo()
        {
        }


        public Control UIControl { get; set; }

        //PLC記憶體類型的一般稱呼，如X、Y、M、D、W、B....
        public string DeviceType { get; set; }


        public int Address { get; set; }


        public int IndexInResultsArray { get; set; }
        public int BitIndexInIndexInResultsArray { get; set; }


    }
}
