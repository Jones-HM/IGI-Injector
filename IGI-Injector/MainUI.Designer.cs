
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
            this.statusLbl = new System.Windows.Forms.Label();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.Button();
            this.startGameBtn = new System.Windows.Forms.Button();
            this.ejectBtn = new System.Windows.Forms.Button();
            this.injectBtn = new System.Windows.Forms.Button();
            this.title_lbl = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.Controls.Add(this.statusLbl);
            this.mainPanel.Controls.Add(this.aboutBtn);
            this.mainPanel.Controls.Add(this.browseFile);
            this.mainPanel.Controls.Add(this.startGameBtn);
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
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.statusLbl.Location = new System.Drawing.Point(153, 357);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 31);
            this.statusLbl.TabIndex = 8;
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackColor = System.Drawing.Color.Transparent;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.aboutBtn.ForeColor = System.Drawing.Color.White;
            this.aboutBtn.Location = new System.Drawing.Point(16, 15);
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(4);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(128, 34);
            this.aboutBtn.TabIndex = 7;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // browseFile
            // 
            this.browseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseFile.BackColor = System.Drawing.Color.Transparent;
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.browseFile.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.browseFile.Location = new System.Drawing.Point(196, 153);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(323, 49);
            this.browseFile.TabIndex = 6;
            this.browseFile.Text = "Browse File";
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // startGameBtn
            // 
            this.startGameBtn.AllowDrop = true;
            this.startGameBtn.BackColor = System.Drawing.Color.Transparent;
            this.startGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.startGameBtn.ForeColor = System.Drawing.Color.White;
            this.startGameBtn.Location = new System.Drawing.Point(521, 15);
            this.startGameBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(128, 34);
            this.startGameBtn.TabIndex = 5;
            this.startGameBtn.Text = "Start Game";
            this.startGameBtn.UseVisualStyleBackColor = false;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // ejectBtn
            // 
            this.ejectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ejectBtn.BackColor = System.Drawing.Color.Transparent;
            this.ejectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ejectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ejectBtn.ForeColor = System.Drawing.Color.Tomato;
            this.ejectBtn.Location = new System.Drawing.Point(362, 255);
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
            this.injectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.injectBtn.ForeColor = System.Drawing.Color.LawnGreen;
            this.injectBtn.Location = new System.Drawing.Point(196, 255);
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
            this.title_lbl.Location = new System.Drawing.Point(149, 66);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(425, 50);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "Project I.G.I -Injector";
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
            this.Text = "Project I.G.I-Injector - HM";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.Button injectBtn;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Button ejectBtn;
        internal System.Windows.Forms.Label statusLbl;
    }
}

