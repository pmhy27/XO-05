using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using CustomizedControls;

namespace XO_05
{
    /// <summary>單筆 PLC 讀寫緩衝資料</summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]    // 允許展開編輯
    public class PLCBuffer : INotifyPropertyChanged
    {
    

        [Category("PLC"), Description("裝置類型，如 D、M、X…")]
        public string DeviceType { get; set; }

        [Category("PLC"), Description("位址 (十進位)")]
        public int Address { get; set; }

        private short _value;
        [Category("PLC"), Description("資料值")]
        public short Value { get{return _value;} 
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            } 
        
        }

        public bool IsChanged { get; set; }

        public List<PlcInteractable> UsedByList = new List<PlcInteractable>();  

        public override string ToString()
        {
            return string.Format("{0}{1} = {2}", DeviceType, Address, Value);
        }

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

        public static string MakeKey(PLCBuffer b)
        {
            return b.DeviceType + b.Address;
        }


        public int IndexInResultsArray { get; set; }
        public int BitIndexInIndexInResultsArray { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}

