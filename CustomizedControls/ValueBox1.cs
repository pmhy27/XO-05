using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomizedControls
{
    public partial class ValueBox1 : UserControl
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
            set { label1.Text = value; }
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


    }
}
