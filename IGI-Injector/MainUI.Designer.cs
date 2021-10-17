
namespace IGI_Injector
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.startGameBtn = new System.Windows.Forms.Button();
            this.levelStartTxt = new System.Windows.Forms.NumericUpDown();
            this.statusLbl = new System.Windows.Forms.Label();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.Button();
            this.ejectBtn = new System.Windows.Forms.Button();
            this.injectBtn = new System.Windows.Forms.Button();
            this.title_lbl = new System.Windows.Forms.Label();
            this.autoInjectCb = new System.Windows.Forms.CheckBox();
            this.windowCb = new System.Windows.Forms.CheckBox();
            this.fullCb = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelStartTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.Controls.Add(this.fullCb);
            this.mainPanel.Controls.Add(this.windowCb);
            this.mainPanel.Controls.Add(this.autoInjectCb);
            this.mainPanel.Controls.Add(this.startGameBtn);
            this.mainPanel.Controls.Add(this.levelStartTxt);
            this.mainPanel.Controls.Add(this.statusLbl);
            this.mainPanel.Controls.Add(this.aboutBtn);
            this.mainPanel.Controls.Add(this.browseFile);
            this.mainPanel.Controls.Add(this.ejectBtn);
            this.mainPanel.Controls.Add(this.injectBtn);
            this.mainPanel.Controls.Add(this.title_lbl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(662, 391);
            this.mainPanel.TabIndex = 5;
            // 
            // startGameBtn
            // 
            this.startGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.startGameBtn.ForeColor = System.Drawing.Color.SpringGreen;
            this.startGameBtn.Location = new System.Drawing.Point(158, 250);
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
            this.levelStartTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.levelStartTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.levelStartTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.levelStartTxt.Location = new System.Drawing.Point(382, 250);
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
            this.levelStartTxt.Size = new System.Drawing.Size(154, 30);
            this.levelStartTxt.TabIndex = 43;
            this.levelStartTxt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.statusLbl.Location = new System.Drawing.Point(167, 348);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 25);
            this.statusLbl.TabIndex = 8;
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackColor = System.Drawing.Color.Transparent;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.aboutBtn.Location = new System.Drawing.Point(598, 22);
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(4);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(51, 41);
            this.aboutBtn.TabIndex = 7;
            this.aboutBtn.Text = "?";
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // browseFile
            // 
            this.browseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseFile.BackColor = System.Drawing.Color.Transparent;
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.browseFile.Location = new System.Drawing.Point(156, 76);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(378, 41);
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
            this.ejectBtn.Location = new System.Drawing.Point(375, 162);
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
            this.injectBtn.Location = new System.Drawing.Point(156, 162);
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
            this.title_lbl.Location = new System.Drawing.Point(125, 9);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(409, 50);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "Project I.G.I Injector";
            // 
            // autoInjectCb
            // 
            this.autoInjectCb.AutoSize = true;
            this.autoInjectCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoInjectCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoInjectCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.autoInjectCb.Location = new System.Drawing.Point(158, 204);
            this.autoInjectCb.Name = "autoInjectCb";
            this.autoInjectCb.Size = new System.Drawing.Size(103, 23);
            this.autoInjectCb.TabIndex = 45;
            this.autoInjectCb.Text = "Auto-Inject";
            this.autoInjectCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.autoInjectCb.UseVisualStyleBackColor = true;
            // 
            // windowCb
            // 
            this.windowCb.AutoSize = true;
            this.windowCb.Checked = true;
            this.windowCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.windowCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.windowCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.windowCb.Location = new System.Drawing.Point(156, 290);
            this.windowCb.Name = "windowCb";
            this.windowCb.Size = new System.Drawing.Size(86, 23);
            this.windowCb.TabIndex = 46;
            this.windowCb.Text = "Window";
            this.windowCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.windowCb.UseVisualStyleBackColor = true;
            this.windowCb.CheckedChanged += new System.EventHandler(this.windowCb_CheckedChanged);
            // 
            // fullCb
            // 
            this.fullCb.AutoSize = true;
            this.fullCb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fullCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.fullCb.Location = new System.Drawing.Point(262, 290);
            this.fullCb.Name = "fullCb";
            this.fullCb.Size = new System.Drawing.Size(50, 23);
            this.fullCb.TabIndex = 46;
            this.fullCb.Text = "Full";
            this.fullCb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fullCb.UseVisualStyleBackColor = true;
            this.fullCb.CheckedChanged += new System.EventHandler(this.fullCb_CheckedChanged);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 391);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUI";
            this.Text = "Project I.G.I Injector - HM";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelStartTxt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Button injectBtn;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Button ejectBtn;
        internal System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.NumericUpDown levelStartTxt;
        private System.Windows.Forms.CheckBox autoInjectCb;
        private System.Windows.Forms.CheckBox fullCb;
        private System.Windows.Forms.CheckBox windowCb;
    }
}

