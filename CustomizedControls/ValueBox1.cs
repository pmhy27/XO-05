using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XO_05;
using System.Diagnostics;

namespace CustomizedControls
{
    public partial class ValueBox1 : PlcInteractable
    {

        public ValueBox1()
        {
            this.AutoScaleMode = AutoScaleMode.None;

            InitializeComponent();

            this.Size = new Size(80, 35);
            this.BackColor = Color.Black;
            this.BorderStyle = BorderStyle.FixedSingle;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font("Consolas", 12, FontStyle.Bold);
            this.label1.Text = "1234.5";
 


        }

        [DefaultValue("1234.5")]
        public string Value
        {
            get { return label1.Text; }
            set { label1.Text = value;}
        }

        /// <summary>
        /// 每當 MyInfoPanel 的 Font 屬性被變更時，這個方法就會被觸發。
        /// </summary>
        protected override void OnFontChanged(EventArgs e)
        {
            // 呼叫基底類別的實作
            base.OnFontChanged(e);

            // 將本身的 Font 屬性「同步」到內部的 label1 元件上
            if (this.label1 != null)
            {
                this.label1.Font = this.Font;
            }
        }

        public override PLCBuffer[] ReadPlcBuffers
        {
            get { return _readPlcBuffers; }
            set
            {
                if (value == _readPlcBuffers) return;
                Unhook(_readPlcBuffers);
                _readPlcBuffers = value ?? new PLCBuffer[0];
                Hook(_readPlcBuffers);
            }

        }

        private void Hook(PLCBuffer[] bufs)
        {
            foreach (var b in bufs)
            {
                b.PropertyChanged += PLCBuffer_PropertyChanged;
            }
        }

        private void Unhook(PLCBuffer[] bufs)
        {
            foreach (var b in bufs)
            {
                b.PropertyChanged -= PLCBuffer_PropertyChanged;
            }
        }


        private void PLCBuffer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Value") return;
            SafeInvoke
            (
                () =>
                {
                    var src = (PLCBuffer)sender;
                    foreach (var p in _readPlcBuffers)
                    {
                        if (PLCBuffer.MakeKey(src) == PLCBuffer.MakeKey(p))
                        {
                            p.Value = src.Value;
                        }
                    }

                    UpdateValue();

                }

            );
        }


        private int _decimalPlaces = 0;
        [Category("Display"),Description("數值顯示的小數位數")]
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }

            set 
            {
                if (value < 0) value = 0;
                _decimalPlaces = value;
                UpdateValue();
            }
        
        }

        private void UpdateValue()
        {
            if (_readPlcBuffers == null || _readPlcBuffers.Length == 0) return;
            int raw = _readPlcBuffers[0].Value;
            Value = FormatWithDecimal(raw, _decimalPlaces);

        }

        private string FormatWithDecimal(int raw, int _decimalPlaces)
        {
            if (_decimalPlaces <= 0) return raw.ToString();

            bool neg = raw < 0;
            long abs = Math.Abs((long)raw);

            string s = abs.ToString().PadLeft(_decimalPlaces + 1, '0');
            int idx = s.Length - _decimalPlaces;
            string result = s.Substring(0, idx) + "." + s.Substring(idx);

            return neg ? "-" + result : result;
 
        }

    }
}
