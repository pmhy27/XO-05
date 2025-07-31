using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using XO_05;                         // 引用 PLCBuffer / IPlcDevice

namespace CustomizedControls
{
    public partial class LampButton1 : PlcInteractable
    {
        #region 
        private bool  _lampState    = false;
        private Color _lampOnColor  = Color.Red;
        private Color _lampOffColor = Color.DeepSkyBlue;
        #endregion

       

        public LampButton1()
        {
            InitializeComponent();
            UpdateLamp();

            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new Size(200, 65);
            this.Font = new Font("Microsoft JhengHei", 12, FontStyle.Bold);
            this.btnAction.UseVisualStyleBackColor = false;

        }

        

        #region  Lamp & Button 屬性（
        [Category("Lamp"), Description("燈號目前狀態；True=亮燈")]
        public bool LampState
        {
            get { return _lampState; }
            set { if (_lampState != value) { _lampState = value; UpdateLamp(); } }
        }

        [Category("Lamp")] 
        public Color LampOnColor
        {
            get { return _lampOnColor; }
            set { _lampOnColor = value; UpdateLamp(); }
        }
        [Category("Lamp")] 
        public Color LampOffColor
        {
            get { return _lampOffColor; }
            set { _lampOffColor = value; UpdateLamp(); }
        }


        [Category("Appearance")]
        public string ButtonText
        {
            get { return btnAction.Text; }
            set { btnAction.Text = value; }
        }

        private void UpdateLamp()
        {
            btnAction.BackColor = _lampState ? _lampOnColor : _lampOffColor;
            btnAction.ForeColor = Color.White;
        }

        public event EventHandler ButtonClick
        {
            add    { btnAction.Click += value; }
            remove { btnAction.Click -= value; }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            // 留給外部或後續邏輯
        }
        #endregion

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
            var s = (PLCBuffer)sender;
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

                    ReculcLampStatus();

                }

            );
        }

        private void ReculcLampStatus()
        {
            if (_readPlcBuffers.Length > 0)
            {
                if (_readPlcBuffers[0].Value > 0)
                {
                    _lampState = true;

                }
                else
                {
                    _lampState = false;
                }

                UpdateLamp();
            }

        }


    }

    
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace CustomizedControls
//{
//    public partial class LampButton1 : UserControl
//    {
//        #region 欄位
//        private bool _lampState = false;
//        private Color _lampOnColor = Color.Red;
//        private Color _lampOffColor = Color.DeepSkyBlue;
//        #endregion

//        public LampButton1()
//        {
//            InitializeComponent();
//            UpdateLamp();         // 初始顏色
//            this.AutoScaleMode = AutoScaleMode.None;
//            this.Size = new Size(200, 65);
//            this.Font = new Font("Microsoft JhengHei", 12, FontStyle.Bold);
//        }

//        // 1) Lamp 狀態屬性 —— 控制背景顏色
//        [Category("Lamp"), Description("燈號目前狀態；True=亮燈")]
//        public bool LampState
//        {
//            get { return _lampState; }
//            set
//            {
//                if (_lampState == value) return;
//                _lampState = value;
//                UpdateLamp();
//            }
//        }

//        // 2) 亮燈顏色
//        [Category("Lamp")]
//        public Color LampOnColor
//        {
//            get { return _lampOnColor; }
//            set { _lampOnColor = value; UpdateLamp(); }
//        }

//        // 3) 滅燈顏色
//        [Category("Lamp")]
//        public Color LampOffColor
//        {
//            get { return _lampOffColor; }
//            set { _lampOffColor = value; UpdateLamp(); }
//        }

//        // 4) Button 作用目標（供邏輯層綁定）
//        [Category("PLC")]
//        public string TargetUnit{ get; set; }

//        // 5) Lamp 監控目標（供邏輯層綁定）
//        [Category("PLC")]
//        public string MonitorUnit{ get; set; }

//        // 6) 讓外部可改顯示文字
//        [Category("Appearance")]
//        public string ButtonText
//        {
//            get { return btnAction.Text; }
//            set { btnAction.Text = value; }
//        }

//        // 7) 內部方法：依狀態更新背景色
//        private void UpdateLamp()
//        {
//            btnAction.BackColor = _lampState ? _lampOnColor : _lampOffColor;
//            btnAction.ForeColor = Color.White;
//        }

//        // 8) 將 Button 的 Click 事件向外透傳，方便表單直接訂閱
//        public event EventHandler ButtonClick
//        {
//            add { btnAction.Click += value; }
//            remove { btnAction.Click -= value; }
//        }


//        //按鈕按下的動作
//        private void btnAction_Click(object sender, EventArgs e)
//        {
//            // 先空著
//        }
//    }
//}
