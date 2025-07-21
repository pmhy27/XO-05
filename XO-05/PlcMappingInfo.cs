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
    class PlcMappingInfo
    {

        public bool isBitType = false;


        public PlcMappingInfo()
        {
            CalculateBitIndex();
            DefinebitOrWord();
        }


        public Control UIControl { get; set; }

        //PLC記憶體類型的一般稱呼，如X、Y、M、D、W、B....
        public string DeviceType { get; set; }



        public int address { get; set; }

        //bit位於16個bit中的第幾位
        public int BitIndex { get; set; }



        //算出bit位於16個bit中的第幾位
        private void CalculateBitIndex()
        {
            BitIndex = address % 16;
        }

        private void DefinebitOrWord()
        {
            if (DeviceType == "X" || DeviceType == "Y" || DeviceType == "M" || DeviceType == "L" || DeviceType == "B")
            {
                isBitType = true;
            }
        }

        public string UniqueKey
        {
            get
            {
                // 對於 Bit 設備，Key 應該包含位址和 Bit 索引，以確保唯一性
                // 例如 M100.0 和 M100.4 是不同的對應
                if (this.isBitType)
                {
                    return string.Format("{0}_{1}_{2}", this.DeviceType.ToUpper(), this.address, this.BitIndex);
                }
                // Word 設備的 Key
                return string.Format("{0}_{1}", this.DeviceType.ToUpper(), this.address);
            }
        }

    }
}
