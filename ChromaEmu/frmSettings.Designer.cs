﻿namespace ChromaEmu
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.grpApi = new System.Windows.Forms.GroupBox();
            this.txtIvUrl = new System.Windows.Forms.TextBox();
            this.lblIv = new System.Windows.Forms.Label();
            this.txtKeyUrl = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ttpUpdate = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmuUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpApi.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpApi
            // 
            this.grpApi.Controls.Add(this.txtIvUrl);
            this.grpApi.Controls.Add(this.lblIv);
            this.grpApi.Controls.Add(this.txtKeyUrl);
            this.grpApi.Controls.Add(this.lblKey);
            this.grpApi.Controls.Add(this.label1);
            this.grpApi.Location = new System.Drawing.Point(12, 167);
            this.grpApi.Name = "grpApi";
            this.grpApi.Size = new System.Drawing.Size(402, 151);
            this.grpApi.TabIndex = 6;
            this.grpApi.TabStop = false;
            this.grpApi.Text = "API Settings";
            // 
            // txtIvUrl
            // 
            this.txtIvUrl.Location = new System.Drawing.Point(60, 99);
            this.txtIvUrl.Name = "txtIvUrl";
            this.txtIvUrl.Size = new System.Drawing.Size(326, 27);
            this.txtIvUrl.TabIndex = 11;
            this.txtIvUrl.Text = "https://cc.aqbt.pw/aes/iv";
            // 
            // lblIv
            // 
            this.lblIv.AutoSize = true;
            this.lblIv.Location = new System.Drawing.Point(29, 102);
            this.lblIv.Name = "lblIv";
            this.lblIv.Size = new System.Drawing.Size(25, 20);
            this.lblIv.TabIndex = 10;
            this.lblIv.Text = "IV:";
            // 
            // txtKeyUrl
            // 
            this.txtKeyUrl.Location = new System.Drawing.Point(60, 66);
            this.txtKeyUrl.Name = "txtKeyUrl";
            this.txtKeyUrl.Size = new System.Drawing.Size(325, 27);
            this.txtKeyUrl.TabIndex = 9;
            this.txtKeyUrl.Text = "https://cc.aqbt.pw/aes/key";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(18, 69);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(36, 20);
            this.lblKey.TabIndex = 8;
            this.lblKey.Text = "Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "These are the API URLs to fetch the newest settings from.";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(332, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 28);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.btnUpdate);
            this.grpConfig.Controls.Add(this.txtKey);
            this.grpConfig.Controls.Add(this.label3);
            this.grpConfig.Controls.Add(this.txtIv);
            this.grpConfig.Controls.Add(this.label4);
            this.grpConfig.Location = new System.Drawing.Point(12, 12);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(402, 149);
            this.grpConfig.TabIndex = 0;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Config";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.Location = new System.Drawing.Point(353, 89);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(32, 32);
            this.btnUpdate.TabIndex = 5;
            this.ttpUpdate.SetToolTip(this.btnUpdate, "Updates the current config using the API URLs defined below.");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(53, 25);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(332, 27);
            this.txtKey.TabIndex = 2;
            this.txtKey.Text = "XvKPGDg58NThZqkxvRezPCgp7uteUJ7T";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Key:";
            // 
            // txtIv
            // 
            this.txtIv.Location = new System.Drawing.Point(53, 56);
            this.txtIv.Name = "txtIv";
            this.txtIv.Size = new System.Drawing.Size(332, 27);
            this.txtIv.TabIndex = 4;
            this.txtIv.Text = "ExhefwVupUfpaQeOeVC0OyISWp7VALwn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "IV:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEmuUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 104);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Emulator";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "URL:";
            // 
            // txtEmuUrl
            // 
            this.txtEmuUrl.Location = new System.Drawing.Point(60, 61);
            this.txtEmuUrl.Name = "txtEmuUrl";
            this.txtEmuUrl.Size = new System.Drawing.Size(325, 27);
            this.txtEmuUrl.TabIndex = 15;
            this.txtEmuUrl.Text = "https://chromaemu.000webhostapp.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "This is the API used to emulate the key exchange.";
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(426, 474);
            this.Controls.Add(this.grpConfig);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpApi);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Settings - ChromaEmu";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpApi.ResumeLayout(false);
            this.grpApi.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpApi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKeyUrl;
        private System.Windows.Forms.TextBox txtIvUrl;
        private System.Windows.Forms.Label lblIv;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip ttpUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmuUrl;
        private System.Windows.Forms.Label label2;
    }
}