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
    public partial class MainPagePageControl : Page
    {
        PageTools pageTools = new PageTools();
  


        public MainPagePageControl()
        {
            InitializeComponent();
            FindAllPlcInteractables((Control)this);
            GetAllReadPlcBuffers();
        }

        public void InitilizeLampDataMappings()
        {
                 
        }

        private void lampButton_Inline_Click(object sender, EventArgs e)
        {

        }





    }

}
