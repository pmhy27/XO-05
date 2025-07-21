using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D; // 為了使用 GraphicsPath 和 SmoothingMode
using System.Windows.Forms;

namespace CustomizedControls
{
    [System.Diagnostics.DebuggerStepThrough]
    public class CircularLamp1 : Control // 直接繼承自 Control
    {
        // ----------------- 屬性 (Properties) -----------------

        // 私有欄位，用來儲存狀態和顏色
        private bool _isOn = false;
        private Color _onColor = Color.LimeGreen;
        private Color _offColor = Color.LightSeaGreen;

        // 公開屬性，讓外部可以設定燈的顏色 (會顯示在 Visual Studio 的屬性視窗中)
        [Category("Appearance")]
        [Description("燈亮起時的顏色")]
        public Color OnColor
        {
            get { return _onColor; }
            set { _onColor = value; this.Invalidate(); } // 當屬性改變時，通知控制項重繪
        }

        [Category("Appearance")]
        [Description("燈熄滅時的顏色")]
        public Color OffColor
        {
            get { return _offColor; }
            set { _offColor = value; this.Invalidate(); }
        }

        // 公開屬性，用來控制燈的開關狀態
        [Category("Behavior")]
        [Description("設定或取得燈的開關狀態")]
        public bool IsOn
        {
            get { return _isOn; }
            set { _isOn = value; this.Invalidate(); }
        }

        // ----------------- 建構子 (Constructor) -----------------

        public CircularLamp1()
        {
            // 設定一個預設大小，最好是正方形
            this.Size = new Size(40, 40);

            // 啟用雙緩衝區，防止繪圖時閃爍，讓動畫或切換更平順
            this.DoubleBuffered = true;
        }

        // ----------------- 繪圖與形狀設定 -----------------

        // 當控制項大小改變時，這個方法會被呼叫
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // --- 這是讓控制項變圓形的魔法 ---
            // 建立一個圖形路徑
            using (GraphicsPath path = new GraphicsPath())
            {
                // 將一個與控制項一樣大的橢圓 (在這裡是圓形) 加入到路徑中
                path.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);

                // 將這個圓形路徑設定為控制項的顯示區域
                this.Region = new Region(path);
            }
        }

        // 當控制項需要重繪時，這個方法會被呼叫
        protected override void OnPaint(PaintEventArgs e)
        {
            // 我們不需要呼叫 base.OnPaint(e)，因為我們要完全自訂繪圖
            // base.OnPaint(e); 

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // 高品質抗鋸齒繪圖

            // 根據 IsOn 狀態選擇要使用的顏色
            Color lampColor = this.IsOn ? this.OnColor : this.OffColor;

            // 用筆刷填滿整個客戶區 (因為 Region 已經是圓形，所以只會填滿圓形區域)
            using (SolidBrush brush = new SolidBrush(lampColor))
            {
                g.FillEllipse(brush, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            }

            // 畫一個外框，增加質感
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                g.DrawEllipse(pen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            }
        }
    }
}