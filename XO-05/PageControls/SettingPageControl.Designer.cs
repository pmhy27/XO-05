namespace XO_05.PageControls
{
    partial class SettingPageControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UI_NetworkNo = new System.Windows.Forms.TextBox();
            this.UI_StationNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Lamp_ConnectionStatus = new CustomizedControls.CircularLamp1();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.circularLamp11 = new CustomizedControls.CircularLamp1();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.circularLamp13 = new CustomizedControls.CircularLamp1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Network No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Station No.";
            // 
            // UI_NetworkNo
            // 
            this.UI_NetworkNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_NetworkNo.Location = new System.Drawing.Point(204, 98);
            this.UI_NetworkNo.Name = "UI_NetworkNo";
            this.UI_NetworkNo.Size = new System.Drawing.Size(68, 31);
            this.UI_NetworkNo.TabIndex = 2;
            // 
            // UI_StationNo
            // 
            this.UI_StationNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UI_StationNo.Location = new System.Drawing.Point(204, 157);
            this.UI_StationNo.Name = "UI_StationNo";
            this.UI_StationNo.Size = new System.Drawing.Size(68, 31);
            this.UI_StationNo.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(100, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Connection Status";
            // 
            // Lamp_ConnectionStatus
            // 
            this.Lamp_ConnectionStatus.IsOn = false;
            this.Lamp_ConnectionStatus.Location = new System.Drawing.Point(252, 31);
            this.Lamp_ConnectionStatus.Name = "Lamp_ConnectionStatus";
            this.Lamp_ConnectionStatus.OffColor = System.Drawing.Color.Red;
            this.Lamp_ConnectionStatus.OnColor = System.Drawing.Color.Lime;
            this.Lamp_ConnectionStatus.Size = new System.Drawing.Size(40, 40);
            this.Lamp_ConnectionStatus.TabIndex = 5;
            this.Lamp_ConnectionStatus.Text = "circularLamp11";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Heart Beat -> PLC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "<- PLC Heart Beat";
            // 
            // circularLamp11
            // 
            this.circularLamp11.IsOn = true;
            this.circularLamp11.Location = new System.Drawing.Point(251, 321);
            this.circularLamp11.Name = "circularLamp11";
            this.circularLamp11.OffColor = System.Drawing.Color.Red;
            this.circularLamp11.OnColor = System.Drawing.Color.Lime;
            this.circularLamp11.Size = new System.Drawing.Size(40, 40);
            this.circularLamp11.TabIndex = 9;
            this.circularLamp11.Text = "circularLamp11";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(167, 344);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 31);
            this.textBox1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bit Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Bit Address";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(167, 451);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(68, 31);
            this.textBox3.TabIndex = 16;
            // 
            // circularLamp13
            // 
            this.circularLamp13.IsOn = false;
            this.circularLamp13.Location = new System.Drawing.Point(251, 428);
            this.circularLamp13.Name = "circularLamp13";
            this.circularLamp13.OffColor = System.Drawing.Color.Red;
            this.circularLamp13.OnColor = System.Drawing.Color.Lime;
            this.circularLamp13.Size = new System.Drawing.Size(40, 40);
            this.circularLamp13.TabIndex = 15;
            this.circularLamp13.Text = "circularLamp13";
            // 
            // SettingPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.circularLamp13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.circularLamp11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Lamp_ConnectionStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UI_StationNo);
            this.Controls.Add(this.UI_NetworkNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingPageControl";
            this.Size = new System.Drawing.Size(1018, 648);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UI_NetworkNo;
        private System.Windows.Forms.TextBox UI_StationNo;
        private System.Windows.Forms.Button button1;
        private CustomizedControls.CircularLamp1 Lamp_ConnectionStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomizedControls.CircularLamp1 circularLamp11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private CustomizedControls.CircularLamp1 circularLamp13;
    }
}
