namespace simplysmart
{
    partial class SimplySmart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimplySmart));
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnectedDevice = new System.Windows.Forms.Label();
            this.axAFXOnlineMain = new Axzkonline.AxAFXOnlineMain();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbDoorNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDoorID = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAFXOnlineMain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Connected Devices: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblConnectedDevice
            // 
            this.lblConnectedDevice.AutoSize = true;
            this.lblConnectedDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedDevice.Location = new System.Drawing.Point(477, 36);
            this.lblConnectedDevice.Name = "lblConnectedDevice";
            this.lblConnectedDevice.Size = new System.Drawing.Size(0, 24);
            this.lblConnectedDevice.TabIndex = 11;
            this.lblConnectedDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // axAFXOnlineMain
            // 
            this.axAFXOnlineMain.Location = new System.Drawing.Point(12, 87);
            this.axAFXOnlineMain.Name = "axAFXOnlineMain";
            this.axAFXOnlineMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAFXOnlineMain.OcxState")));
            this.axAFXOnlineMain.Size = new System.Drawing.Size(75, 23);
            this.axAFXOnlineMain.TabIndex = 12;
            this.axAFXOnlineMain.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 116);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(511, 331);
            this.txtLog.TabIndex = 13;
            this.txtLog.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "Menu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.reconnectDevicesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            // 
            // reconnectDevicesToolStripMenuItem
            // 
            this.reconnectDevicesToolStripMenuItem.Name = "reconnectDevicesToolStripMenuItem";
            this.reconnectDevicesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.reconnectDevicesToolStripMenuItem.Text = "Reconnect Devices";
            this.reconnectDevicesToolStripMenuItem.Click += new System.EventHandler(this.reconnectDevicesToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(119, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Open Door";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbDoorNames
            // 
            this.cmbDoorNames.FormattingEnabled = true;
            this.cmbDoorNames.Location = new System.Drawing.Point(12, 41);
            this.cmbDoorNames.Name = "cmbDoorNames";
            this.cmbDoorNames.Size = new System.Drawing.Size(101, 21);
            this.cmbDoorNames.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "No of Doors";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDoorID
            // 
            this.lblDoorID.AutoSize = true;
            this.lblDoorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoorID.Location = new System.Drawing.Point(418, 73);
            this.lblDoorID.Name = "lblDoorID";
            this.lblDoorID.Size = new System.Drawing.Size(0, 24);
            this.lblDoorID.TabIndex = 18;
            this.lblDoorID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Crimson;
            this.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_clear.Location = new System.Drawing.Point(210, 39);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(76, 23);
            this.btn_clear.TabIndex = 19;
            this.btn_clear.Text = "Clear Data";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // SimplySmart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 459);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lblDoorID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDoorNames);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.axAFXOnlineMain);
            this.Controls.Add(this.lblConnectedDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimplySmart";
            this.Text = "SimplySmart";
            this.Load += new System.EventHandler(this.SimplySmart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAFXOnlineMain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConnectedDevice;
        private Axzkonline.AxAFXOnlineMain axAFXOnlineMain;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reconnectDevicesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbDoorNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDoorID;
        private System.Windows.Forms.Button btn_clear;
    }
}