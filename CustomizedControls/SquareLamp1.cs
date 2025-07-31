using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XO_05;



namespace CustomizedControls
{
    [System.Diagnostics.DebuggerStepThrough]
    public partial class SquareLamp1 : PlcInteractable
    {
        #region 欄位
        private bool _lampState = false;
        private Color _lampOnColor = Color.Lime;
        private Color _lampOffColor = Color.LightSeaGreen;
        private int _BorderThickness = 0;
        #endregion




        public SquareLamp1()
        {
            InitializeComponent();
            UpdateLamp();         // 初始顏色
            this.AutoScaleMode = AutoScaleMode.None;
        }



        // 1) Lamp 狀態屬性 —— 控制背景顏色
        [Category("Lamp"), Description("燈號目前狀態；True=亮燈")]
        public bool LampState
        {
            get { return _lampState; }
            set
            {
                if (_lampState == value) return;
                _lampState = value;
                UpdateLamp();
            }
        }



        // 2) 亮燈顏色
        [Category("Lamp")]
        public Color LampOnColor
        {
            get { return _lampOnColor; }
            set { _lampOnColor = value; UpdateLamp(); }
        }



        // 3) 滅燈顏色
        [Category("Lamp")]
        public Color LampOffColor
        {
            get { return _lampOffColor; }
            set { _lampOffColor = value; UpdateLamp(); }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 使用 'using' 語法，當離開大括號時，borderPen 會自動被 Dispose()
            using (Pen borderPen = new Pen(Color.Black, _BorderThickness))
            {
                Rectangle borderRect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(borderPen, borderRect);
            }
        }



        // 7) 內部方法：依狀態更新背景色

        private void UpdateLamp()
        {
            this.BackColor = _lampState ? _lampOnColor : _lampOffColor;
        }



        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.Invalidate(); // 當背景顏色改變時，也通知重繪
        }



        [Category("Appearance")]

        public int BorderThickness
        {
            get { return _BorderThickness; }
            set { _BorderThickness = value; }
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