using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomizedControls;

namespace XO_05.PageControls
{
    [System.Diagnostics.DebuggerStepThrough]
    public partial class TempMonitorPageControl : UserControl
    {
        private Dictionary<string,ValueBox1> valueBoxes = new Dictionary<string,ValueBox1>();

        enum ColorFillingStyle
        { 
            ByRow,
            ByColumn,
        }


        public TempMonitorPageControl()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            BuildGrid(tableLayoutPanel1, "SlotB-8", ColorFillingStyle.ByRow, Color.Aquamarine, Color.PeachPuff);
            BuildGrid(tableLayoutPanel2, "Slot9-R", ColorFillingStyle.ByRow, Color.Aquamarine, Color.PeachPuff);
            BuildGrid(tableLayoutPanel3, "Heat-Air", ColorFillingStyle.ByColumn, Color.ForestGreen, Color.LightCoral);

        }




        private void BuildGrid(TableLayoutPanel tableLayoutPanel, String namePrefix, ColorFillingStyle colorFillingStyle, Color fillingColor1, Color fillingColor2)
        {

            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel.RowCount; j++)
                {
                    Panel cell = new Panel
                    {
                        Dock = DockStyle.Fill,
                        Margin = Padding.Empty,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    if (colorFillingStyle == ColorFillingStyle.ByRow)
                    {
                        if (j % 2 == 0)
                        {
                            cell.BackColor = fillingColor1;
                        }
                        else
                        {
                            cell.BackColor = fillingColor2;
                        }

                    }
                    else if (colorFillingStyle == ColorFillingStyle.ByColumn) 
                    {
                        if (i % 2 == 0)
                        {
                            cell.BackColor = fillingColor1;
                        }
                        else
                        {
                            cell.BackColor = fillingColor2;
                        }
                    
                    }

                    

                    tableLayoutPanel.Controls.Add(cell, i, j);

                    ValueBox1 valueBox1 = new ValueBox1();
                    valueBox1.Name = string.Format("{0}_{1}.{2}", namePrefix, i, j);
                    valueBox1.Size = new Size(cell.Width - 10, cell.Height - 10);
                    valueBox1.Location = new Point(4, 4);

                    cell.Controls.Add(valueBox1);

                    this.valueBoxes.Add(valueBox1.Name, valueBox1);
                    //CreateCell(tableLayoutPanel, i, j, namePrefix);

                }

            }
                 
        }

        private void CreateCell(TableLayoutPanel tableLayoutPanel, int i, int j, String namePrefix) 
        {

            Panel cell = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (j % 2 == 0)
            {
                cell.BackColor = Color.Aquamarine;
            }
            else
            {
                cell.BackColor = Color.PeachPuff;
            }

            tableLayoutPanel.Controls.Add(cell, i, j);

            ValueBox1 valueBox1 = new ValueBox1();
            valueBox1.Name = string.Format("{0}_{1}.{2}",namePrefix,i,j);
            valueBox1.Size = new Size(cell.Width - 10, cell.Height - 10);
            valueBox1.Location = new Point(4, 4);

            cell.Controls.Add(valueBox1);

            this.valueBoxes.Add(valueBox1.Name, valueBox1);


        }

        private void TempMonitorPageControl_Load(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }
            

            





    }


}
