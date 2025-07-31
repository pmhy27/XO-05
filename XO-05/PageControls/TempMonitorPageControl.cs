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
    //[System.Diagnostics.DebuggerStepThrough]
    public partial class TempMonitorPageControl : Page
    {
        private Dictionary<string,ValueBox1> valueBoxes = new Dictionary<string,ValueBox1>();

        enum ColorFillingStyle
        { 
            ByRow,
            ByColumn,
        }

        //string[] Block1_Column = new string[] { "FrontR", "FrontL", "Certer", "BackR", "BackL" };
        //string[] Block1_Row = new string[] { "SlotB", "Slot1", "Slot2", "Slot3", "Slot4", "Slot5", "Slot6", "Slot7", "Slot8" };
        //string[] Block2_Column = new string[] { "FrontR", "FrontL", "Certer", "BackR", "BackL" };
        //string[] Block2_Row = new string[] { "SlotB", "Slot1", "Slot2", "Slot3", "Slot4", "Slot5", "Slot6", "Slot7", "Slot8" };


        public TempMonitorPageControl()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            BuildGrid(tableLayoutPanel1, "SlotB-8", ColorFillingStyle.ByRow, Color.Aquamarine, Color.PeachPuff);
            BuildGrid(tableLayoutPanel2, "Slot9-R", ColorFillingStyle.ByRow, Color.Aquamarine, Color.PeachPuff);
            BuildGrid(tableLayoutPanel3, "Heat-Air", ColorFillingStyle.ByColumn, Color.ForestGreen, Color.LightCoral);

            MapValueBoxToCell();
            FindAllPlcInteractables((Control)this);
            GetAllReadPlcBuffers();

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

                    //var bufs = new PLCBuffer[] { new PLCBuffer() };
                    //ValueBox1 valueBox1 = new ValueBox1() {ReadPlcBuffers = bufs};
                    ValueBox1 valueBox1 = new ValueBox1() {};
                    valueBox1.ReadBufferCount = 1;
                    valueBox1.DecimalPlaces = 1;
                    valueBox1.Name = string.Format("{0}_{1}.{2}", namePrefix, i+1, j+1);
                    valueBox1.Size = new Size(cell.Width - 10, cell.Height - 10);
                    valueBox1.Location = new Point(4, 4);
                    cell.Controls.Add(valueBox1);

                    this.valueBoxes.Add(valueBox1.Name, valueBox1);
                    //CreateCell(tableLayoutPanel, i, j, namePrefix);

                }

            }
                 
        }


        private void MapValueBoxToCell()
        {

            foreach (var cellinfo in _cellInfoTable)
            {
                ValueBox1 box = new ValueBox1();
                if (valueBoxes.TryGetValue(cellinfo.name, out box))
                {
                    box.ReadPlcBuffers[0].DeviceType = cellinfo.devicetype;
                    box.ReadPlcBuffers[0].Address = cellinfo.address;
                }
            }
        }

        //private void CreateCell(TableLayoutPanel tableLayoutPanel, int i, int j, String namePrefix) 
        //{

        //    Panel cell = new Panel
        //    {
        //        Dock = DockStyle.Fill,
        //        Margin = Padding.Empty,
        //        BorderStyle = BorderStyle.FixedSingle
        //    };

        //    if (j % 2 == 0)
        //    {
        //        cell.BackColor = Color.Aquamarine;
        //    }
        //    else
        //    {
        //        cell.BackColor = Color.PeachPuff;
        //    }

        //    tableLayoutPanel.Controls.Add(cell, i, j);

        //    ValueBox1 valueBox1 = new ValueBox1();
        //    valueBox1.Name = string.Format("{0}_{1}.{2}",namePrefix,i+1,j+1);
        //    valueBox1.Size = new Size(cell.Width - 10, cell.Height - 10);
        //    valueBox1.Location = new Point(4, 4);

        //    cell.Controls.Add(valueBox1);

        //    this.valueBoxes.Add(valueBox1.Name, valueBox1);


        //}


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

        #region //CellInfoMappingTable
        readonly CellInfo[] _cellInfoTable = new CellInfo[]
        {
            new CellInfo {name = "SlotB-8_1.1",devicetype ="D", address = 1000 },
            new CellInfo {name = "SlotB-8_1.2",devicetype ="D", address = 1001 },
            new CellInfo {name = "SlotB-8_1.3",devicetype ="D", address = 1002 },
            new CellInfo {name = "SlotB-8_1.4",devicetype ="D", address = 1003 },
            new CellInfo {name = "SlotB-8_1.5",devicetype ="D", address = 1004 },
            new CellInfo {name = "SlotB-8_2.1",devicetype ="D", address = 1050 },
            new CellInfo {name = "SlotB-8_2.2",devicetype ="D", address = 1051 },
            new CellInfo {name = "SlotB-8_2.3",devicetype ="D", address = 1052 },
            new CellInfo {name = "SlotB-8_2.4",devicetype ="D", address = 1053 },
            new CellInfo {name = "SlotB-8_2.5",devicetype ="D", address = 1054 },
            new CellInfo {name = "SlotB-8_3.1",devicetype ="D", address = 1100 },
            new CellInfo {name = "SlotB-8_3.2",devicetype ="D", address = 1101 },
            new CellInfo {name = "SlotB-8_3.3",devicetype ="D", address = 1102 },
            new CellInfo {name = "SlotB-8_3.4",devicetype ="D", address = 1103 },
            new CellInfo {name = "SlotB-8_3.5",devicetype ="D", address = 1104 },
            new CellInfo {name = "SlotB-8_4.1",devicetype ="D", address = 1150 },
            new CellInfo {name = "SlotB-8_4.2",devicetype ="D", address = 1151 },
            new CellInfo {name = "SlotB-8_4.3",devicetype ="D", address = 1152 },
            new CellInfo {name = "SlotB-8_4.4",devicetype ="D", address = 1153 },
            new CellInfo {name = "SlotB-8_4.5",devicetype ="D", address = 1154 },
            new CellInfo {name = "SlotB-8_5.1",devicetype ="D", address = 1200 },
            new CellInfo {name = "SlotB-8_5.2",devicetype ="D", address = 1201 },
            new CellInfo {name = "SlotB-8_5.3",devicetype ="D", address = 1202 },
            new CellInfo {name = "SlotB-8_5.4",devicetype ="D", address = 1203 },
            new CellInfo {name = "SlotB-8_5.5",devicetype ="D", address = 1204 },
            new CellInfo {name = "SlotB-8_6.1",devicetype ="D", address = 1250 },
            new CellInfo {name = "SlotB-8_6.2",devicetype ="D", address = 1251 },
            new CellInfo {name = "SlotB-8_6.3",devicetype ="D", address = 1252 },
            new CellInfo {name = "SlotB-8_6.4",devicetype ="D", address = 1253 },
            new CellInfo {name = "SlotB-8_6.5",devicetype ="D", address = 1254 },
            new CellInfo {name = "SlotB-8_7.1",devicetype ="D", address = 1300 },
            new CellInfo {name = "SlotB-8_7.2",devicetype ="D", address = 1301 },
            new CellInfo {name = "SlotB-8_7.3",devicetype ="D", address = 1302 },
            new CellInfo {name = "SlotB-8_7.4",devicetype ="D", address = 1303 },
            new CellInfo {name = "SlotB-8_7.5",devicetype ="D", address = 1304 },
            new CellInfo {name = "SlotB-8_8.1",devicetype ="D", address = 1350 },
            new CellInfo {name = "SlotB-8_8.2",devicetype ="D", address = 1351 },
            new CellInfo {name = "SlotB-8_8.3",devicetype ="D", address = 1352 },
            new CellInfo {name = "SlotB-8_8.4",devicetype ="D", address = 1353 },
            new CellInfo {name = "SlotB-8_8.5",devicetype ="D", address = 1354 },
            new CellInfo {name = "SlotB-8_9.1",devicetype ="D", address = 1400 },
            new CellInfo {name = "SlotB-8_9.2",devicetype ="D", address = 1401 },
            new CellInfo {name = "SlotB-8_9.3",devicetype ="D", address = 1402 },
            new CellInfo {name = "SlotB-8_9.4",devicetype ="D", address = 1403 },
            new CellInfo {name = "SlotB-8_9.5",devicetype ="D", address = 1404 },
            new CellInfo {name = "Slot9-R_1.1",devicetype ="D", address = 1450 },
            new CellInfo {name = "Slot9-R_1.2",devicetype ="D", address = 1451 },
            new CellInfo {name = "Slot9-R_1.3",devicetype ="D", address = 1452 },
            new CellInfo {name = "Slot9-R_1.4",devicetype ="D", address = 1453 },
            new CellInfo {name = "Slot9-R_1.5",devicetype ="D", address = 1454 },
            new CellInfo {name = "Slot9-R_2.1",devicetype ="D", address = 1500 },
            new CellInfo {name = "Slot9-R_2.2",devicetype ="D", address = 1501 },
            new CellInfo {name = "Slot9-R_2.3",devicetype ="D", address = 1502 },
            new CellInfo {name = "Slot9-R_2.4",devicetype ="D", address = 1503 },
            new CellInfo {name = "Slot9-R_2.5",devicetype ="D", address = 1504 },
            new CellInfo {name = "Slot9-R_3.1",devicetype ="D", address = 1550 },
            new CellInfo {name = "Slot9-R_3.2",devicetype ="D", address = 1551 },
            new CellInfo {name = "Slot9-R_3.3",devicetype ="D", address = 1552 },
            new CellInfo {name = "Slot9-R_3.4",devicetype ="D", address = 1553 },
            new CellInfo {name = "Slot9-R_3.5",devicetype ="D", address = 1554 },
            new CellInfo {name = "Slot9-R_4.1",devicetype ="D", address = 1600 },
            new CellInfo {name = "Slot9-R_4.2",devicetype ="D", address = 1601 },
            new CellInfo {name = "Slot9-R_4.3",devicetype ="D", address = 1602 },
            new CellInfo {name = "Slot9-R_4.4",devicetype ="D", address = 1603 },
            new CellInfo {name = "Slot9-R_4.5",devicetype ="D", address = 1604 },
            new CellInfo {name = "Slot9-R_5.1",devicetype ="D", address = 1650 },
            new CellInfo {name = "Slot9-R_5.2",devicetype ="D", address = 1651 },
            new CellInfo {name = "Slot9-R_5.3",devicetype ="D", address = 1652 },
            new CellInfo {name = "Slot9-R_5.4",devicetype ="D", address = 1653 },
            new CellInfo {name = "Slot9-R_5.5",devicetype ="D", address = 1654 },
            new CellInfo {name = "Slot9-R_6.1",devicetype ="D", address = 1700 },
            new CellInfo {name = "Slot9-R_6.2",devicetype ="D", address = 1701 },
            new CellInfo {name = "Slot9-R_6.3",devicetype ="D", address = 1702 },
            new CellInfo {name = "Slot9-R_6.4",devicetype ="D", address = 1703 },
            new CellInfo {name = "Slot9-R_6.5",devicetype ="D", address = 1704 },
            new CellInfo {name = "Slot9-R_7.1",devicetype ="D", address = 1750 },
            new CellInfo {name = "Slot9-R_7.2",devicetype ="D", address = 1751 },
            new CellInfo {name = "Slot9-R_7.3",devicetype ="D", address = 1752 },
            new CellInfo {name = "Slot9-R_7.4",devicetype ="D", address = 1753 },
            new CellInfo {name = "Slot9-R_7.5",devicetype ="D", address = 1754 },
            new CellInfo {name = "Slot9-R_8.1",devicetype ="D", address = 1800 },
            new CellInfo {name = "Slot9-R_8.2",devicetype ="D", address = 1801 },
            new CellInfo {name = "Slot9-R_8.3",devicetype ="D", address = 1802 },
            new CellInfo {name = "Slot9-R_8.4",devicetype ="D", address = 1803 },
            new CellInfo {name = "Slot9-R_8.5",devicetype ="D", address = 1804 },
            new CellInfo {name = "Slot9-R_9.1",devicetype ="D", address = 1850 },
            new CellInfo {name = "Slot9-R_9.2",devicetype ="D", address = 1851 },
            new CellInfo {name = "Slot9-R_9.3",devicetype ="D", address = 1852 },
            new CellInfo {name = "Slot9-R_9.4",devicetype ="D", address = 1853 },
            new CellInfo {name = "Slot9-R_9.5",devicetype ="D", address = 1854 },
            new CellInfo {name = "Heat-Air_1.1",devicetype ="D", address = 1900 },
            new CellInfo {name = "Heat-Air_1.2",devicetype ="D", address = 1901 },
            new CellInfo {name = "Heat-Air_1.3",devicetype ="D", address = 1902 },
            new CellInfo {name = "Heat-Air_1.4",devicetype ="D", address = 1903 },
            new CellInfo {name = "Heat-Air_1.5",devicetype ="D", address = 1904 },
            new CellInfo {name = "Heat-Air_1.6",devicetype ="D", address = 1905 },
            new CellInfo {name = "Heat-Air_2.1",devicetype ="D", address = 1950 },
            new CellInfo {name = "Heat-Air_2.2",devicetype ="D", address = 1951 },
            new CellInfo {name = "Heat-Air_2.3",devicetype ="D", address = 1952 },
            new CellInfo {name = "Heat-Air_2.4",devicetype ="D", address = 1953 },
            new CellInfo {name = "Heat-Air_2.5",devicetype ="D", address = 1954 },
            new CellInfo {name = "Heat-Air_2.6",devicetype ="D", address = 1955 },
        };
        #endregion


    }


   public class CellInfo
   {
    public string name;
    public string devicetype;
    public int address;
   }


}
