using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CustomizedControls // 請確保命名空間與您的專案一致
{
    /// <summary>
    /// 一個具備開關燈變色功能的特殊標籤 (Label)
    /// </summary>
    public class LabelLamp1 : Label // 繼承自 Label
    {
        #region 私有欄位 (Private Fields)

        // 用來儲存燈的開關狀態
        private bool _lampIsOn = false;

        // 用來儲存開燈和關燈時的顏色
        private Color _onColor = Color.Red;
        private Color _offColor = Color.White; // 預設關燈顏色為系統控制項的背景色

        #endregion

        #region 自訂的公開屬性 (Public Properties)

        // [Category("...")] 和 [Description("...")] 是為了讓屬性在 Visual Studio 的屬性視窗中顯示得更專業、更易於理解。

        [Category("Lamp")]
        [Description("設定或取得燈的開關狀態。True 為亮燈，False 為滅燈。")]
        public bool LampIsOn
        {
            get { return _lampIsOn; }
            set
            {
                _lampIsOn = value;
                UpdateColor(); // 當狀態改變時，呼叫更新顏色的方法
            }
        }

        [Category("Lamp")]
        [Description("設定燈亮起時的背景顏色。")]
        public Color OnColor
        {
            get { return _onColor; }
            set
            {
                _onColor = value;
                UpdateColor(); // 當顏色設定改變時，也要更新
            }
        }

        [Category("Lamp")]
        [Description("設定燈熄滅時的背景顏色。")]
        public Color OffColor
        {
            get { return _offColor; }
            set
            {
                _offColor = value;
                UpdateColor(); // 當顏色設定改變時，也要更新
            }
        }

        #endregion

        #region 建構子 (Constructor)

        // 當這個元件被建立時，會執行的初始方法
        public LabelLamp1()
        {
            // 設定初始的背景顏色
            UpdateColor();
        }

        #endregion

        #region 私有輔助方法 (Private Helper Method)

        /// <summary>
        /// 根據目前的開關狀態和顏色設定，來更新 Label 的背景色
        /// </summary>
        private void UpdateColor()
        {
            // 這是核心邏輯：如果 _lampIsOn 是 true，就使用 OnColor；否則，就使用 OffColor。
            // 然後將選定的顏色，設定給這個 Label 天生就有的 BackColor 屬性。
            this.BackColor = _lampIsOn ? _onColor : _offColor;
        }

        #endregion
    }
}