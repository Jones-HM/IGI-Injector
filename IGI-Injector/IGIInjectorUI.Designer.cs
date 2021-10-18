
namespace IGI_Injector
{
    partial class IGIInjectorUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IGIInjectorUI));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.setGamePathBtn = new System.Windows.Forms.Button();
            this.multiDLLCb = new System.Windows.Forms.CheckBox();
            this.delayTxt = new System.Windows.Forms.NumericUpDown();
            this.delayLbl = new System.Windows.Forms.Label();
            this.gameTypeDD = new System.Windows.Forms.ComboBox();
            this.gameTypeLbl = new System.Windows.Forms.Label();
            this.formMoverPanel = new System.Windows.Forms.Panel();
            this.aboutBtn = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.fullCb = new System.Windows.Forms.CheckBox();
            this.windowCb = new System.Windows.Forms.CheckBox();
            this.autoInjectCb = new System.Windows.Forms.CheckBox();
            this.startGameBtn = new System.Windows.Forms.Button();
            this.levelStartTxt = new System.Windows.Forms.NumericUpDown();
            this.statusLbl = new System.Windows.Forms.Label();
            this.browseFile = new System.Windows.Forms.Button();
            this.ejectBtn = new System.Windows.Forms.Button();
            this.injectBtn = new System.Windows.Forms.Button();
            this.title_lbl = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelStartTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.mainPanel.Controls.Add(this.setGamePathBtn);
            this.mainPanel.Controls.Add(this.multiDLLCb);
            this.mainPanel.Controls.Add(this.delayTxt);
            this.mainPanel.Controls.Add(this.delayLbl);
            this.mainPanel.Controls.Add(this.gameTypeDD);
            this.mainPanel.Controls.Add(this.gameTypeLbl);
            this.mainPanel.Controls.Add(this.formMoverPanel);
            this.mainPanel.Controls.Add(this.aboutBtn);
            this.mainPanel.Controls.Add(this.minimizeBtn);
            this.mainPanel.Controls.Add(this.closeBtn);
            this.mainPanel.Controls.Add(this.versionLbl);
            this.mainPanel.Controls.Add(this.fullCb);
            this.mainPanel.Controls.Add(this.windowCb);
            this.mainPanel.Controls.Add(this.autoInjectCb);
            this.mainPanel.Controls.Add(this.startGameBtn);
            this.mainPanel.Controls.Add(this.levelStartTxt);
            this.mainPanel.Controls.Add(this.statusLbl);
            this.mainPanel.Controls.Add(this.browseFile);
            this.mainPanel.Controls.Add(this.ejectBtn);
            this.mainPanel.Controls.Add(this.injectBtn);
            this.mainPanel.Controls.Add(this.title_lbl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(828, 488);
            this.mainPanel.TabIndex = 5;
            // 
            // setGamePathBtn
            // 
            this.setGamePathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setGamePathBtn.BackColor = System.Drawing.Color.Transparent;
            this.setGamePathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setGamePathBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setGamePathBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.setGamePathBtn.Location = new System.Drawing.Point(63, 164);
            this.setGamePathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.setGamePathBtn.Name = "setGamePathBtn";
            this.setGamePathBtn.Size = new System.Drawing.Size(666, 41);
            this.setGamePathBtn.TabIndex = 58;
            this.setGamePathBtn.Text = "Selelct Game Path";
            this.setGamePathBtn.UseVisualStyleBackColor = false;
            this.setGamePathBtn.Click += new System.EventHandler(this.setGamePathBtn_Click);
            // 
            // multiDLLCb
            // 
            this.multiDLLCb.AutoSize = true;
            this.multiDLLCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.multiDLLCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiDLLCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.multiDLLCb.Location = new System.Drawing.Point(176, 278);
            this.multiDLLCb.Name = "multiDLLCb";
            this.multiDLLCb.Size = new System.Drawing.Size(88, 23);
            this.multiDLLCb.TabIndex = 57;
            this.multiDLLCb.Text = "Multi-DLL";
            this.multiDLLCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.multiDLLCb.UseVisualStyleBackColor = true;
            this.multiDLLCb.CheckedChanged += new System.EventHandler(this.multiDLLCb_CheckedChanged);
            // 
            // delayTxt
            // 
            this.delayTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.delayTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.delayTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.delayTxt.Location = new System.Drawing.Point(564, 242);
            this.delayTxt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.delayTxt.Name = "delayTxt";
            this.delayTxt.Size = new System.Drawing.Size(159, 30);
            this.delayTxt.TabIndex = 56;
            this.delayTxt.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.delayTxt.ValueChanged += new System.EventHandler(this.delayTxt_ValueChanged);
            // 
            // delayLbl
            // 
            this.delayLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.delayLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.delayLbl.Location = new System.Drawing.Point(443, 238);
            this.delayLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.delayLbl.Name = "delayLbl";
            this.delayLbl.Size = new System.Drawing.Size(110, 33);
            this.delayLbl.TabIndex = 55;
            this.delayLbl.Text = "Delay :";
            this.delayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameTypeDD
            // 
            this.gameTypeDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.gameTypeDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameTypeDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameTypeDD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.gameTypeDD.FormattingEnabled = true;
            this.gameTypeDD.Items.AddRange(new object[] {
            "Project IGI 1",
            "Project IGI 2"});
            this.gameTypeDD.Location = new System.Drawing.Point(574, 351);
            this.gameTypeDD.Name = "gameTypeDD";
            this.gameTypeDD.Size = new System.Drawing.Size(149, 24);
            this.gameTypeDD.TabIndex = 54;
            this.gameTypeDD.SelectedIndexChanged += new System.EventHandler(this.gameTypeDD_SelectedIndexChanged);
            this.gameTypeDD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameTypeDD_MouseClick);
            // 
            // gameTypeLbl
            // 
            this.gameTypeLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.gameTypeLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gameTypeLbl.Location = new System.Drawing.Point(455, 348);
            this.gameTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameTypeLbl.Name = "gameTypeLbl";
            this.gameTypeLbl.Size = new System.Drawing.Size(98, 33);
            this.gameTypeLbl.TabIndex = 53;
            this.gameTypeLbl.Text = "Game :";
            this.gameTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formMoverPanel
            // 
            this.formMoverPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.formMoverPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formMoverPanel.Location = new System.Drawing.Point(0, 0);
            this.formMoverPanel.Margin = new System.Windows.Forms.Padding(4);
            this.formMoverPanel.Name = "formMoverPanel";
            this.formMoverPanel.Size = new System.Drawing.Size(828, 12);
            this.formMoverPanel.TabIndex = 51;
            // 
            // aboutBtn
            // 
            this.aboutBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.aboutBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.aboutBtn.Location = new System.Drawing.Point(652, 13);
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(52, 46);
            this.aboutBtn.TabIndex = 50;
            this.aboutBtn.Text = "?";
            this.aboutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(712, 13);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(52, 46);
            this.minimizeBtn.TabIndex = 49;
            this.minimizeBtn.Text = "_";
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.closeBtn.ForeColor = System.Drawing.Color.Tomato;
            this.closeBtn.Location = new System.Drawing.Point(772, 15);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(52, 46);
            this.closeBtn.TabIndex = 48;
            this.closeBtn.Text = "x";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.versionLbl.Location = new System.Drawing.Point(713, 456);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(82, 18);
            this.versionLbl.TabIndex = 47;
            this.versionLbl.Text = "Version 1.0";
            // 
            // fullCb
            // 
            this.fullCb.AutoSize = true;
            this.fullCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fullCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.fullCb.Location = new System.Drawing.Point(176, 388);
            this.fullCb.Name = "fullCb";
            this.fullCb.Size = new System.Drawing.Size(50, 23);
            this.fullCb.TabIndex = 46;
            this.fullCb.Text = "Full";
            this.fullCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fullCb.UseVisualStyleBackColor = true;
            this.fullCb.CheckedChanged += new System.EventHandler(this.fullCb_CheckedChanged);
            // 
            // windowCb
            // 
            this.windowCb.AutoSize = true;
            this.windowCb.Checked = true;
            this.windowCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.windowCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.windowCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.windowCb.Location = new System.Drawing.Point(70, 388);
            this.windowCb.Name = "windowCb";
            this.windowCb.Size = new System.Drawing.Size(86, 23);
            this.windowCb.TabIndex = 46;
            this.windowCb.Text = "Window";
            this.windowCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.windowCb.UseVisualStyleBackColor = true;
            this.windowCb.CheckedChanged += new System.EventHandler(this.windowCb_CheckedChanged);
            // 
            // autoInjectCb
            // 
            this.autoInjectCb.AutoSize = true;
            this.autoInjectCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoInjectCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoInjectCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.autoInjectCb.Location = new System.Drawing.Point(70, 278);
            this.autoInjectCb.Name = "autoInjectCb";
            this.autoInjectCb.Size = new System.Drawing.Size(103, 23);
            this.autoInjectCb.TabIndex = 45;
            this.autoInjectCb.Text = "Auto-Inject";
            this.autoInjectCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.autoInjectCb.UseVisualStyleBackColor = true;
            this.autoInjectCb.CheckedChanged += new System.EventHandler(this.autoInjectCb_CheckedChanged);
            // 
            // startGameBtn
            // 
            this.startGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.startGameBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.startGameBtn.Location = new System.Drawing.Point(63, 348);
            this.startGameBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(165, 33);
            this.startGameBtn.TabIndex = 44;
            this.startGameBtn.Text = "Start Level";
            this.startGameBtn.UseVisualStyleBackColor = true;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // levelStartTxt
            // 
            this.levelStartTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.levelStartTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.levelStartTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.levelStartTxt.Location = new System.Drawing.Point(276, 348);
            this.levelStartTxt.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.levelStartTxt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelStartTxt.Name = "levelStartTxt";
            this.levelStartTxt.Size = new System.Drawing.Size(159, 30);
            this.levelStartTxt.TabIndex = 43;
            this.levelStartTxt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelStartTxt.ValueChanged += new System.EventHandler(this.levelStartTxt_ValueChanged);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.statusLbl.Location = new System.Drawing.Point(246, 438);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 25);
            this.statusLbl.TabIndex = 8;
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // browseFile
            // 
            this.browseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseFile.BackColor = System.Drawing.Color.Transparent;
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.browseFile.Location = new System.Drawing.Point(63, 92);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(666, 41);
            this.browseFile.TabIndex = 6;
            this.browseFile.Text = "Browse File";
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // ejectBtn
            // 
            this.ejectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ejectBtn.BackColor = System.Drawing.Color.Transparent;
            this.ejectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ejectBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.ejectBtn.ForeColor = System.Drawing.Color.Tomato;
            this.ejectBtn.Location = new System.Drawing.Point(276, 236);
            this.ejectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ejectBtn.Name = "ejectBtn";
            this.ejectBtn.Size = new System.Drawing.Size(159, 35);
            this.ejectBtn.TabIndex = 0;
            this.ejectBtn.Text = "Eject DLL";
            this.ejectBtn.UseVisualStyleBackColor = false;
            this.ejectBtn.Click += new System.EventHandler(this.ejectBtn_Click);
            // 
            // injectBtn
            // 
            this.injectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.injectBtn.BackColor = System.Drawing.Color.Transparent;
            this.injectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.injectBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.injectBtn.ForeColor = System.Drawing.Color.SpringGreen;
            this.injectBtn.Location = new System.Drawing.Point(61, 236);
            this.injectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.injectBtn.Name = "injectBtn";
            this.injectBtn.Size = new System.Drawing.Size(167, 35);
            this.injectBtn.TabIndex = 0;
            this.injectBtn.Text = "Inject DLL";
            this.injectBtn.UseVisualStyleBackColor = false;
            this.injectBtn.Click += new System.EventHandler(this.injectBtn_Click);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.BackColor = System.Drawing.Color.Transparent;
            this.title_lbl.Font = new System.Drawing.Font("Harrington", 25F, System.Drawing.FontStyle.Bold);
            this.title_lbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.title_lbl.Location = new System.Drawing.Point(148, 15);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(409, 50);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "Project I.G.I Injector";
            // 
            // IGIInjectorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 488);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IGIInjectorUI";
            this.Text = "Project I.G.I Injector - HM";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelStartTxt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button injectBtn;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Button ejectBtn;
        internal System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.CheckBox autoInjectCb;
        private System.Windows.Forms.CheckBox fullCb;
        private System.Windows.Forms.CheckBox windowCb;
        internal System.Windows.Forms.NumericUpDown levelStartTxt;
        internal System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label aboutBtn;
        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Panel formMoverPanel;
        private System.Windows.Forms.ComboBox gameTypeDD;
        private System.Windows.Forms.Label gameTypeLbl;
        private System.Windows.Forms.Label delayLbl;
        internal System.Windows.Forms.NumericUpDown delayTxt;
        private System.Windows.Forms.CheckBox multiDLLCb;
        internal System.Windows.Forms.Button setGamePathBtn;
    }
}

