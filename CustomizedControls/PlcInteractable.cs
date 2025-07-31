using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XO_05;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomizedControls
{
    public  class PlcInteractable : UserControl
    {

        #region
        protected  PLCBuffer[] _readPlcBuffers = new PLCBuffer[0];
        protected  PLCBuffer[] _writePlcBuffers = new PLCBuffer[0];
        #endregion


        // ===== 可直接在屬性視窗展開與編輯 =====
        [Category("PLC"), Description("PLC 讀取緩衝區"),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PLCBuffer[] ReadPlcBuffers
        {
            get { return _readPlcBuffers; }
            set {
                    _readPlcBuffers = value ?? new PLCBuffer[0];
                    ReadBufferCount = _readPlcBuffers.Length;
                }
        }

        [Category("PLC"), Description("PLC 寫入緩衝區"),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual PLCBuffer[] WritePlcBuffers
        {
            get { return _writePlcBuffers; }
            set 
            {
                _writePlcBuffers = value ?? new PLCBuffer[0];
                WriteBufferCount = _writePlcBuffers.Length;
            }
        }

        // ===== 讓設計師先決定「筆數」，再展開填值 =====
        private int _readCount;
        [Category("PLC"), Description("讀取緩衝區筆數")]
        public int ReadBufferCount
        {
            get { return _readCount; }
            set
            {
                if (value < 0) return;
                if (value != _readCount)
                {
                    _readCount = value;
                    ReadPlcBuffers = ResizeArray(_readPlcBuffers, value);
                }
            }
        }

        private int _writeCount;
        [Category("PLC"), Description("寫入緩衝區筆數")]
        public int WriteBufferCount
        {
            get { return _writeCount; }
            set
            {
                if (value < 0) return;
                if (value != _writeCount)
                {
                    _writeCount = value;
                    WritePlcBuffers = ResizeArray(_writePlcBuffers, value);
                }
            }
        }

        /// <summary>調整陣列長度並保留既有資料</summary>
        private static PLCBuffer[] ResizeArray(PLCBuffer[] src, int newLen)
        {
            var dst = new PLCBuffer[newLen];
            if (src != null)
                Array.Copy(src, dst, Math.Min(src.Length, newLen));

            // 確保每格都有實體，設計師才能展開編輯
            for (int i = 0; i < newLen; i++)
                if (dst[i] == null) dst[i] = new PLCBuffer();

            return dst;
        }


        protected void SafeInvoke(Action uiAction)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(uiAction);
            }
            else
            {
                uiAction();
            }
        }




    }
}
