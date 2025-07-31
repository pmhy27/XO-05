using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XO_05.PageControls
{
    public partial class SystemRecipeSettingPageControl : Page
    {
        public SystemRecipeSettingPageControl()
        {
            InitializeComponent();
            FindAllPlcInteractables((Control)this);
            GetAllReadPlcBuffers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void transparentLabel1_Click(object sender, EventArgs e)
        {

        }

        private void SystemRecipeSettingPageControl_Load(object sender, EventArgs e)
        {

        }
    }
}
