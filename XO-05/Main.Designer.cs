namespace XO_05
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHost = new System.Windows.Forms.Panel();
            this.PollingTimer = new System.Windows.Forms.Timer(this.components);
            this.dataWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // panelHost
            // 
            this.panelHost.BackColor = System.Drawing.SystemColors.Menu;
            this.panelHost.Location = new System.Drawing.Point(0, 0);
            this.panelHost.Name = "panelHost";
            this.panelHost.Size = new System.Drawing.Size(1018, 648);
            this.panelHost.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHost;
        private PageControls.NavigationButtonsPanel navigationButtonsPanel1;
        private System.Windows.Forms.Timer PollingTimer;
        private System.ComponentModel.BackgroundWorker dataWorker;
    }
}