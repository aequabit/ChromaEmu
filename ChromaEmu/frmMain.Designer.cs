namespace ChromaEmu
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpNetwork = new System.Windows.Forms.GroupBox();
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.ttpTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblApiStatus = new System.Windows.Forms.Label();
            this.lblDnsStatus = new System.Windows.Forms.Label();
            this.lblHttpStatus = new System.Windows.Forms.Label();
            this.lblDns = new System.Windows.Forms.Label();
            this.lblApi = new System.Windows.Forms.Label();
            this.lblHttp = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpNetwork.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNetwork
            // 
            this.grpNetwork.Controls.Add(this.cmbInterfaces);
            this.grpNetwork.Location = new System.Drawing.Point(13, 43);
            this.grpNetwork.Name = "grpNetwork";
            this.grpNetwork.Size = new System.Drawing.Size(370, 68);
            this.grpNetwork.TabIndex = 0;
            this.grpNetwork.TabStop = false;
            this.grpNetwork.Text = "Network Interface";
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(24, 26);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.Size = new System.Drawing.Size(323, 28);
            this.cmbInterfaces.TabIndex = 1;
            this.ttpTooltip.SetToolTip(this.cmbInterfaces, "Select your currently used Network Interface.");
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(293, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(71, 30);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.ttpTooltip.SetToolTip(this.btnStop, "Stop the emulator.");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(71, 30);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.ttpTooltip.SetToolTip(this.btnStart, "Start the emulator.");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblApiStatus);
            this.groupBox3.Controls.Add(this.lblDnsStatus);
            this.groupBox3.Controls.Add(this.lblHttpStatus);
            this.groupBox3.Controls.Add(this.lblDns);
            this.groupBox3.Controls.Add(this.lblApi);
            this.groupBox3.Controls.Add(this.lblHttp);
            this.groupBox3.Location = new System.Drawing.Point(13, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 118);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Services";
            this.ttpTooltip.SetToolTip(this.groupBox3, "Status of the ChromaEmu services");
            // 
            // lblApiStatus
            // 
            this.lblApiStatus.AutoSize = true;
            this.lblApiStatus.ForeColor = System.Drawing.Color.Red;
            this.lblApiStatus.Location = new System.Drawing.Point(65, 25);
            this.lblApiStatus.Name = "lblApiStatus";
            this.lblApiStatus.Size = new System.Drawing.Size(52, 20);
            this.lblApiStatus.TabIndex = 4;
            this.lblApiStatus.Text = "offline";
            this.ttpTooltip.SetToolTip(this.lblApiStatus, "ChromaEmu API status.");
            // 
            // lblDnsStatus
            // 
            this.lblDnsStatus.AutoSize = true;
            this.lblDnsStatus.ForeColor = System.Drawing.Color.Red;
            this.lblDnsStatus.Location = new System.Drawing.Point(65, 85);
            this.lblDnsStatus.Name = "lblDnsStatus";
            this.lblDnsStatus.Size = new System.Drawing.Size(52, 20);
            this.lblDnsStatus.TabIndex = 8;
            this.lblDnsStatus.Text = "offline";
            this.ttpTooltip.SetToolTip(this.lblDnsStatus, "ChromaEmu DNS status.");
            // 
            // lblHttpStatus
            // 
            this.lblHttpStatus.AutoSize = true;
            this.lblHttpStatus.ForeColor = System.Drawing.Color.Red;
            this.lblHttpStatus.Location = new System.Drawing.Point(65, 55);
            this.lblHttpStatus.Name = "lblHttpStatus";
            this.lblHttpStatus.Size = new System.Drawing.Size(52, 20);
            this.lblHttpStatus.TabIndex = 6;
            this.lblHttpStatus.Text = "offline";
            this.ttpTooltip.SetToolTip(this.lblHttpStatus, "ChromaEmu HTTP status.");
            // 
            // lblDns
            // 
            this.lblDns.AutoSize = true;
            this.lblDns.Location = new System.Drawing.Point(17, 85);
            this.lblDns.Name = "lblDns";
            this.lblDns.Size = new System.Drawing.Size(46, 20);
            this.lblDns.TabIndex = 7;
            this.lblDns.Text = "DNS: ";
            this.ttpTooltip.SetToolTip(this.lblDns, "ChromaEmu DNS status.");
            // 
            // lblApi
            // 
            this.lblApi.AutoSize = true;
            this.lblApi.Location = new System.Drawing.Point(18, 25);
            this.lblApi.Name = "lblApi";
            this.lblApi.Size = new System.Drawing.Size(38, 20);
            this.lblApi.TabIndex = 3;
            this.lblApi.Text = "API: ";
            this.ttpTooltip.SetToolTip(this.lblApi, "ChromaEmu API status.");
            // 
            // lblHttp
            // 
            this.lblHttp.AutoSize = true;
            this.lblHttp.Location = new System.Drawing.Point(17, 55);
            this.lblHttp.Name = "lblHttp";
            this.lblHttp.Size = new System.Drawing.Size(51, 20);
            this.lblHttp.TabIndex = 5;
            this.lblHttp.Text = "HTTP: ";
            this.ttpTooltip.SetToolTip(this.lblHttp, "ChromaEmu HTTP status.");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Location = new System.Drawing.Point(13, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 61);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(395, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 313);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpNetwork);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "ChromaEmu - GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpNetwork.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNetwork;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.ToolTip ttpTooltip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDns;
        private System.Windows.Forms.Label lblApi;
        private System.Windows.Forms.Label lblHttp;
        private System.Windows.Forms.Label lblHttpStatus;
        private System.Windows.Forms.Label lblApiStatus;
        private System.Windows.Forms.Label lblDnsStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

