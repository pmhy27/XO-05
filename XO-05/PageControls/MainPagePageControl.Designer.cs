namespace XO_05.PageControls
{
    partial class MainPagePageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            XO_05.PLCBuffer plcBuffer1 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer2 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer3 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer4 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer5 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer6 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer7 = new XO_05.PLCBuffer();
            XO_05.PLCBuffer plcBuffer8 = new XO_05.PLCBuffer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lampButton_Inline = new CustomizedControls.LampButton1();
            this.lampButton_Offline = new CustomizedControls.LampButton1();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lampButton_HeaterOn = new CustomizedControls.LampButton1();
            this.lampButton_HeaterOff = new CustomizedControls.LampButton1();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lampButton_CycleStopOn = new CustomizedControls.LampButton1();
            this.lampButton_CycleStopOff = new CustomizedControls.LampButton1();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.squareLamp12 = new CustomizedControls.SquareLamp1();
            this.squareLamp11 = new CustomizedControls.SquareLamp1();
            this.labelLamp11 = new CustomizedControls.LabelLamp1();
            this.labelLamp12 = new CustomizedControls.LabelLamp1();
            this.labelLamp13 = new CustomizedControls.LabelLamp1();
            this.labelLamp14 = new CustomizedControls.LabelLamp1();
            this.labelLamp15 = new CustomizedControls.LabelLamp1();
            this.labelLamp16 = new CustomizedControls.LabelLamp1();
            this.labelLamp17 = new CustomizedControls.LabelLamp1();
            this.labelLamp18 = new CustomizedControls.LabelLamp1();
            this.lampButton11 = new CustomizedControls.LampButton1();
            this.lampButton12 = new CustomizedControls.LampButton1();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lampButton_Inline);
            this.panel1.Controls.Add(this.lampButton_Offline);
            this.panel1.Location = new System.Drawing.Point(24, 145);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 64);
            this.panel1.TabIndex = 18;
            // 
            // lampButton_Inline
            // 
            this.lampButton_Inline.ButtonText = "Inline";
            this.lampButton_Inline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lampButton_Inline.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton_Inline.LampOnColor = System.Drawing.Color.Red;
            this.lampButton_Inline.LampState = false;
            this.lampButton_Inline.Location = new System.Drawing.Point(5, 6);
            this.lampButton_Inline.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton_Inline.Name = "lampButton_Inline";
            this.lampButton_Inline.ReadBufferCount = 1;
            plcBuffer1.Address = 1200;
            plcBuffer1.BitIndexInIndexInResultsArray = 0;
            plcBuffer1.DeviceType = "L";
            plcBuffer1.IndexInResultsArray = 0;
            plcBuffer1.IsChanged = false;
            plcBuffer1.Value = ((short)(0));
            this.lampButton_Inline.ReadPlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer1};
            this.lampButton_Inline.Size = new System.Drawing.Size(146, 52);
            this.lampButton_Inline.TabIndex = 12;
            this.lampButton_Inline.WriteBufferCount = 2;
            plcBuffer2.Address = 0;
            plcBuffer2.BitIndexInIndexInResultsArray = 0;
            plcBuffer2.DeviceType = null;
            plcBuffer2.IndexInResultsArray = 0;
            plcBuffer2.IsChanged = false;
            plcBuffer2.Value = ((short)(0));
            plcBuffer3.Address = 0;
            plcBuffer3.BitIndexInIndexInResultsArray = 0;
            plcBuffer3.DeviceType = null;
            plcBuffer3.IndexInResultsArray = 0;
            plcBuffer3.IsChanged = false;
            plcBuffer3.Value = ((short)(0));
            this.lampButton_Inline.WritePlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer2,
        plcBuffer3};
            this.lampButton_Inline.Click += new System.EventHandler(this.lampButton_Inline_Click);
            // 
            // lampButton_Offline
            // 
            this.lampButton_Offline.ButtonText = "Offline";
            this.lampButton_Offline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lampButton_Offline.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton_Offline.LampOnColor = System.Drawing.Color.Red;
            this.lampButton_Offline.LampState = false;
            this.lampButton_Offline.Location = new System.Drawing.Point(161, 6);
            this.lampButton_Offline.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton_Offline.Name = "lampButton_Offline";
            this.lampButton_Offline.ReadBufferCount = 1;
            plcBuffer4.Address = 1201;
            plcBuffer4.BitIndexInIndexInResultsArray = 0;
            plcBuffer4.DeviceType = "L";
            plcBuffer4.IndexInResultsArray = 0;
            plcBuffer4.IsChanged = false;
            plcBuffer4.Value = ((short)(0));
            this.lampButton_Offline.ReadPlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer4};
            this.lampButton_Offline.Size = new System.Drawing.Size(146, 52);
            this.lampButton_Offline.TabIndex = 13;
            this.lampButton_Offline.WriteBufferCount = 0;
            this.lampButton_Offline.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.lampButton_HeaterOn);
            this.panel2.Controls.Add(this.lampButton_HeaterOff);
            this.panel2.Location = new System.Drawing.Point(24, 235);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 64);
            this.panel2.TabIndex = 19;
            // 
            // lampButton_HeaterOn
            // 
            this.lampButton_HeaterOn.ButtonText = "Heater On";
            this.lampButton_HeaterOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lampButton_HeaterOn.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton_HeaterOn.LampOnColor = System.Drawing.Color.Red;
            this.lampButton_HeaterOn.LampState = false;
            this.lampButton_HeaterOn.Location = new System.Drawing.Point(5, 6);
            this.lampButton_HeaterOn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton_HeaterOn.Name = "lampButton_HeaterOn";
            this.lampButton_HeaterOn.ReadBufferCount = 1;
            plcBuffer5.Address = 1202;
            plcBuffer5.BitIndexInIndexInResultsArray = 0;
            plcBuffer5.DeviceType = "L";
            plcBuffer5.IndexInResultsArray = 0;
            plcBuffer5.IsChanged = false;
            plcBuffer5.Value = ((short)(0));
            this.lampButton_HeaterOn.ReadPlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer5};
            this.lampButton_HeaterOn.Size = new System.Drawing.Size(146, 52);
            this.lampButton_HeaterOn.TabIndex = 14;
            this.lampButton_HeaterOn.WriteBufferCount = 0;
            this.lampButton_HeaterOn.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // lampButton_HeaterOff
            // 
            this.lampButton_HeaterOff.ButtonText = "Heater Off";
            this.lampButton_HeaterOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lampButton_HeaterOff.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton_HeaterOff.LampOnColor = System.Drawing.Color.Red;
            this.lampButton_HeaterOff.LampState = false;
            this.lampButton_HeaterOff.Location = new System.Drawing.Point(161, 6);
            this.lampButton_HeaterOff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton_HeaterOff.Name = "lampButton_HeaterOff";
            this.lampButton_HeaterOff.ReadBufferCount = 1;
            plcBuffer6.Address = 1203;
            plcBuffer6.BitIndexInIndexInResultsArray = 0;
            plcBuffer6.DeviceType = "L";
            plcBuffer6.IndexInResultsArray = 0;
            plcBuffer6.IsChanged = false;
            plcBuffer6.Value = ((short)(0));
            this.lampButton_HeaterOff.ReadPlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer6};
            this.lampButton_HeaterOff.Size = new System.Drawing.Size(146, 52);
            this.lampButton_HeaterOff.TabIndex = 15;
            this.lampButton_HeaterOff.WriteBufferCount = 0;
            this.lampButton_HeaterOff.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.lampButton_CycleStopOn);
            this.panel3.Controls.Add(this.lampButton_CycleStopOff);
            this.panel3.Location = new System.Drawing.Point(24, 323);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 64);
            this.panel3.TabIndex = 20;
            // 
            // lampButton_CycleStopOn
            // 
            this.lampButton_CycleStopOn.ButtonText = "Cycle Stop ON";
            this.lampButton_CycleStopOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lampButton_CycleStopOn.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton_CycleStopOn.LampOnColor = System.Drawing.Color.Red;
            this.lampButton_CycleStopOn.LampState = false;
            this.lampButton_CycleStopOn.Location = new System.Drawing.Point(5, 6);
            this.lampButton_CycleStopOn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton_CycleStopOn.Name = "lampButton_CycleStopOn";
            this.lampButton_CycleStopOn.ReadBufferCount = 1;
            plcBuffer7.Address = 1204;
            plcBuffer7.BitIndexInIndexInResultsArray = 0;
            plcBuffer7.DeviceType = "L";
            plcBuffer7.IndexInResultsArray = 0;
            plcBuffer7.IsChanged = false;
            plcBuffer7.Value = ((short)(0));
            this.lampButton_CycleStopOn.ReadPlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer7};
            this.lampButton_CycleStopOn.Size = new System.Drawing.Size(146, 52);
            this.lampButton_CycleStopOn.TabIndex = 16;
            this.lampButton_CycleStopOn.WriteBufferCount = 0;
            this.lampButton_CycleStopOn.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // lampButton_CycleStopOff
            // 
            this.lampButton_CycleStopOff.ButtonText = "Cycle Stop OFF";
            this.lampButton_CycleStopOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lampButton_CycleStopOff.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton_CycleStopOff.LampOnColor = System.Drawing.Color.Red;
            this.lampButton_CycleStopOff.LampState = false;
            this.lampButton_CycleStopOff.Location = new System.Drawing.Point(161, 6);
            this.lampButton_CycleStopOff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton_CycleStopOff.Name = "lampButton_CycleStopOff";
            this.lampButton_CycleStopOff.ReadBufferCount = 1;
            plcBuffer8.Address = 1205;
            plcBuffer8.BitIndexInIndexInResultsArray = 0;
            plcBuffer8.DeviceType = "L";
            plcBuffer8.IndexInResultsArray = 0;
            plcBuffer8.IsChanged = false;
            plcBuffer8.Value = ((short)(0));
            this.lampButton_CycleStopOff.ReadPlcBuffers = new XO_05.PLCBuffer[] {
        plcBuffer8};
            this.lampButton_CycleStopOff.Size = new System.Drawing.Size(146, 52);
            this.lampButton_CycleStopOff.TabIndex = 17;
            this.lampButton_CycleStopOff.WriteBufferCount = 0;
            this.lampButton_CycleStopOff.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(427, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "節電模式啟動流程";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(742, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "節電模式關閉流程";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(464, 278);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 24);
            this.label7.TabIndex = 29;
            // 
            // squareLamp12
            // 
            this.squareLamp12.BackColor = System.Drawing.Color.LightSeaGreen;
            this.squareLamp12.BorderThickness = 5;
            this.squareLamp12.LampOffColor = System.Drawing.Color.LightSeaGreen;
            this.squareLamp12.LampOnColor = System.Drawing.Color.Lime;
            this.squareLamp12.LampState = false;
            this.squareLamp12.Location = new System.Drawing.Point(708, 58);
            this.squareLamp12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.squareLamp12.Name = "squareLamp12";
            this.squareLamp12.ReadBufferCount = 0;
            this.squareLamp12.ReadPlcBuffers = new XO_05.PLCBuffer[0];
            this.squareLamp12.Size = new System.Drawing.Size(264, 452);
            this.squareLamp12.TabIndex = 22;
            this.squareLamp12.WriteBufferCount = 0;
            this.squareLamp12.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // squareLamp11
            // 
            this.squareLamp11.BackColor = System.Drawing.Color.LightSeaGreen;
            this.squareLamp11.BorderThickness = 5;
            this.squareLamp11.LampOffColor = System.Drawing.Color.LightSeaGreen;
            this.squareLamp11.LampOnColor = System.Drawing.Color.Lime;
            this.squareLamp11.LampState = false;
            this.squareLamp11.Location = new System.Drawing.Point(392, 58);
            this.squareLamp11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.squareLamp11.Name = "squareLamp11";
            this.squareLamp11.ReadBufferCount = 0;
            this.squareLamp11.ReadPlcBuffers = new XO_05.PLCBuffer[0];
            this.squareLamp11.Size = new System.Drawing.Size(264, 452);
            this.squareLamp11.TabIndex = 21;
            this.squareLamp11.WriteBufferCount = 0;
            this.squareLamp11.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // labelLamp11
            // 
            this.labelLamp11.AutoSize = true;
            this.labelLamp11.BackColor = System.Drawing.Color.White;
            this.labelLamp11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp11.LampIsOn = false;
            this.labelLamp11.Location = new System.Drawing.Point(402, 112);
            this.labelLamp11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp11.Name = "labelLamp11";
            this.labelLamp11.OffColor = System.Drawing.Color.White;
            this.labelLamp11.OnColor = System.Drawing.Color.Red;
            this.labelLamp11.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp11.Size = new System.Drawing.Size(246, 36);
            this.labelLamp11.TabIndex = 34;
            this.labelLamp11.Text = "1. 節電模式啟動確認中";
            this.labelLamp11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp12
            // 
            this.labelLamp12.AutoSize = true;
            this.labelLamp12.BackColor = System.Drawing.Color.White;
            this.labelLamp12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp12.LampIsOn = false;
            this.labelLamp12.Location = new System.Drawing.Point(440, 211);
            this.labelLamp12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp12.Name = "labelLamp12";
            this.labelLamp12.OffColor = System.Drawing.Color.White;
            this.labelLamp12.OnColor = System.Drawing.Color.Red;
            this.labelLamp12.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp12.Size = new System.Drawing.Size(177, 36);
            this.labelLamp12.TabIndex = 35;
            this.labelLamp12.Text = "2. 確認爐內無片";
            this.labelLamp12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp13
            // 
            this.labelLamp13.AutoSize = true;
            this.labelLamp13.BackColor = System.Drawing.Color.White;
            this.labelLamp13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp13.LampIsOn = false;
            this.labelLamp13.Location = new System.Drawing.Point(463, 309);
            this.labelLamp13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp13.Name = "labelLamp13";
            this.labelLamp13.OffColor = System.Drawing.Color.White;
            this.labelLamp13.OnColor = System.Drawing.Color.Red;
            this.labelLamp13.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp13.Size = new System.Drawing.Size(131, 36);
            this.labelLamp13.TabIndex = 36;
            this.labelLamp13.Text = "3. 入料擋片";
            this.labelLamp13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp14
            // 
            this.labelLamp14.AutoSize = true;
            this.labelLamp14.BackColor = System.Drawing.Color.White;
            this.labelLamp14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp14.LampIsOn = false;
            this.labelLamp14.Location = new System.Drawing.Point(450, 413);
            this.labelLamp14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp14.Name = "labelLamp14";
            this.labelLamp14.OffColor = System.Drawing.Color.White;
            this.labelLamp14.OnColor = System.Drawing.Color.Red;
            this.labelLamp14.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp14.Size = new System.Drawing.Size(154, 36);
            this.labelLamp14.TabIndex = 37;
            this.labelLamp14.Text = "4. 節電降溫中";
            this.labelLamp14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp15
            // 
            this.labelLamp15.AutoSize = true;
            this.labelLamp15.BackColor = System.Drawing.Color.White;
            this.labelLamp15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp15.LampIsOn = false;
            this.labelLamp15.Location = new System.Drawing.Point(718, 112);
            this.labelLamp15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp15.Name = "labelLamp15";
            this.labelLamp15.OffColor = System.Drawing.Color.White;
            this.labelLamp15.OnColor = System.Drawing.Color.Red;
            this.labelLamp15.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp15.Size = new System.Drawing.Size(246, 36);
            this.labelLamp15.TabIndex = 38;
            this.labelLamp15.Text = "1. 節電模式關閉確認中";
            this.labelLamp15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp16
            // 
            this.labelLamp16.AutoSize = true;
            this.labelLamp16.BackColor = System.Drawing.Color.White;
            this.labelLamp16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp16.LampIsOn = false;
            this.labelLamp16.Location = new System.Drawing.Point(792, 211);
            this.labelLamp16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp16.Name = "labelLamp16";
            this.labelLamp16.OffColor = System.Drawing.Color.White;
            this.labelLamp16.OnColor = System.Drawing.Color.Red;
            this.labelLamp16.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp16.Size = new System.Drawing.Size(108, 36);
            this.labelLamp16.TabIndex = 39;
            this.labelLamp16.Text = "2. 升溫中";
            this.labelLamp16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp17
            // 
            this.labelLamp17.AutoSize = true;
            this.labelLamp17.BackColor = System.Drawing.Color.White;
            this.labelLamp17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp17.LampIsOn = false;
            this.labelLamp17.Location = new System.Drawing.Point(732, 309);
            this.labelLamp17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp17.Name = "labelLamp17";
            this.labelLamp17.OffColor = System.Drawing.Color.White;
            this.labelLamp17.OnColor = System.Drawing.Color.Red;
            this.labelLamp17.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp17.Size = new System.Drawing.Size(223, 36);
            this.labelLamp17.TabIndex = 40;
            this.labelLamp17.Text = "3. 等待溫度達到穩定";
            this.labelLamp17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLamp18
            // 
            this.labelLamp18.AutoSize = true;
            this.labelLamp18.BackColor = System.Drawing.Color.White;
            this.labelLamp18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLamp18.LampIsOn = false;
            this.labelLamp18.Location = new System.Drawing.Point(792, 413);
            this.labelLamp18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLamp18.Name = "labelLamp18";
            this.labelLamp18.OffColor = System.Drawing.Color.White;
            this.labelLamp18.OnColor = System.Drawing.Color.Red;
            this.labelLamp18.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelLamp18.Size = new System.Drawing.Size(108, 36);
            this.labelLamp18.TabIndex = 41;
            this.labelLamp18.Text = "4. 生產中";
            this.labelLamp18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lampButton11
            // 
            this.lampButton11.ButtonText = "啟動節電模式";
            this.lampButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lampButton11.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton11.LampOnColor = System.Drawing.Color.Red;
            this.lampButton11.LampState = false;
            this.lampButton11.Location = new System.Drawing.Point(455, 528);
            this.lampButton11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton11.Name = "lampButton11";
            this.lampButton11.ReadBufferCount = 0;
            this.lampButton11.ReadPlcBuffers = new XO_05.PLCBuffer[0];
            this.lampButton11.Size = new System.Drawing.Size(172, 52);
            this.lampButton11.TabIndex = 42;
            this.lampButton11.WriteBufferCount = 0;
            this.lampButton11.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // lampButton12
            // 
            this.lampButton12.ButtonText = "關閉節電模式";
            this.lampButton12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lampButton12.LampOffColor = System.Drawing.Color.DeepSkyBlue;
            this.lampButton12.LampOnColor = System.Drawing.Color.Red;
            this.lampButton12.LampState = false;
            this.lampButton12.Location = new System.Drawing.Point(759, 528);
            this.lampButton12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lampButton12.Name = "lampButton12";
            this.lampButton12.ReadBufferCount = 0;
            this.lampButton12.ReadPlcBuffers = new XO_05.PLCBuffer[0];
            this.lampButton12.Size = new System.Drawing.Size(172, 52);
            this.lampButton12.TabIndex = 43;
            this.lampButton12.WriteBufferCount = 0;
            this.lampButton12.WritePlcBuffers = new XO_05.PLCBuffer[0];
            // 
            // MainPagePageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lampButton12);
            this.Controls.Add(this.lampButton11);
            this.Controls.Add(this.labelLamp18);
            this.Controls.Add(this.labelLamp17);
            this.Controls.Add(this.labelLamp16);
            this.Controls.Add(this.labelLamp15);
            this.Controls.Add(this.labelLamp14);
            this.Controls.Add(this.labelLamp13);
            this.Controls.Add(this.labelLamp12);
            this.Controls.Add(this.labelLamp11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.squareLamp12);
            this.Controls.Add(this.squareLamp11);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainPagePageControl";
            this.Size = new System.Drawing.Size(1018, 648);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomizedControls.LampButton1 lampButton_CycleStopOff;
        private CustomizedControls.LampButton1 lampButton_CycleStopOn;
        private CustomizedControls.LampButton1 lampButton_HeaterOff;
        private CustomizedControls.LampButton1 lampButton_HeaterOn;
        private CustomizedControls.LampButton1 lampButton_Offline;
        private CustomizedControls.LampButton1 lampButton_Inline;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CustomizedControls.SquareLamp1 squareLamp11;
        private CustomizedControls.SquareLamp1 squareLamp12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private CustomizedControls.LabelLamp1 labelLamp11;
        private CustomizedControls.LabelLamp1 labelLamp12;
        private CustomizedControls.LabelLamp1 labelLamp13;
        private CustomizedControls.LabelLamp1 labelLamp14;
        private CustomizedControls.LabelLamp1 labelLamp15;
        private CustomizedControls.LabelLamp1 labelLamp16;
        private CustomizedControls.LabelLamp1 labelLamp17;
        private CustomizedControls.LabelLamp1 labelLamp18;
        private CustomizedControls.LampButton1 lampButton11;
        private CustomizedControls.LampButton1 lampButton12;

    }
}
