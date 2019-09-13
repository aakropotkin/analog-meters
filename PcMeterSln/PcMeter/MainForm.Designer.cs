namespace PcMeter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cpuTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.memTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.meterTimer = new System.Windows.Forms.Timer(this.components);
            this.comPortUpDown = new System.Windows.Forms.NumericUpDown();
            this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectOnStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.startupInSystemTrayCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.comPortUpDown)).BeginInit();
            this.notifyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(151, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "COM Port:";
            // 
            // cpuTextBox
            // 
            this.cpuTextBox.Location = new System.Drawing.Point(75, 26);
            this.cpuTextBox.Name = "cpuTextBox";
            this.cpuTextBox.ReadOnly = true;
            this.cpuTextBox.Size = new System.Drawing.Size(35, 20);
            this.cpuTextBox.TabIndex = 3;
            this.cpuTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(29, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPU%:";
            // 
            // memTextBox
            // 
            this.memTextBox.Location = new System.Drawing.Point(75, 58);
            this.memTextBox.Name = "memTextBox";
            this.memTextBox.ReadOnly = true;
            this.memTextBox.Size = new System.Drawing.Size(35, 20);
            this.memTextBox.TabIndex = 5;
            this.memTextBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(26, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "MEM%:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 100);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(80, 26);
            this.connectButton.TabIndex = 10;
            this.connectButton.Text = "&Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(98, 100);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(80, 26);
            this.aboutButton.TabIndex = 11;
            this.aboutButton.Text = "&About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(184, 100);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(80, 26);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // meterTimer
            // 
            this.meterTimer.Interval = 500;
            this.meterTimer.Tick += new System.EventHandler(this.meterTimer_Tick);
            // 
            // comPortUpDown
            // 
            this.comPortUpDown.Location = new System.Drawing.Point(213, 15);
            this.comPortUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.comPortUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.comPortUpDown.Name = "comPortUpDown";
            this.comPortUpDown.Size = new System.Drawing.Size(35, 20);
            this.comPortUpDown.TabIndex = 7;
            this.comPortUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mainNotifyIcon
            // 
            this.mainNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.mainNotifyIcon.BalloonTipTitle = "PC Meter";
            this.mainNotifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
            this.mainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mainNotifyIcon.Icon")));
            this.mainNotifyIcon.Text = "PC Meter";
            this.mainNotifyIcon.DoubleClick += new System.EventHandler(this.mainNotifyIcon_DoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.openToolStripMenuItem});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // connectOnStartupCheckbox
            // 
            this.connectOnStartupCheckbox.AutoSize = true;
            this.connectOnStartupCheckbox.Location = new System.Drawing.Point(147, 44);
            this.connectOnStartupCheckbox.Name = "connectOnStartupCheckbox";
            this.connectOnStartupCheckbox.Size = new System.Drawing.Size(106, 17);
            this.connectOnStartupCheckbox.TabIndex = 8;
            this.connectOnStartupCheckbox.Text = "Connect on Start";
            this.connectOnStartupCheckbox.UseVisualStyleBackColor = true;
            // 
            // startupInSystemTrayCheckbox
            // 
            this.startupInSystemTrayCheckbox.AutoSize = true;
            this.startupInSystemTrayCheckbox.Location = new System.Drawing.Point(147, 68);
            this.startupInSystemTrayCheckbox.Name = "startupInSystemTrayCheckbox";
            this.startupInSystemTrayCheckbox.Size = new System.Drawing.Size(106, 17);
            this.startupInSystemTrayCheckbox.TabIndex = 9;
            this.startupInSystemTrayCheckbox.Text = "Start in Sys. Tray";
            this.startupInSystemTrayCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 134);
            this.Controls.Add(this.startupInSystemTrayCheckbox);
            this.Controls.Add(this.connectOnStartupCheckbox);
            this.Controls.Add(this.comPortUpDown);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.memTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cpuTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "PC Meter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comPortUpDown)).EndInit();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cpuTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox memTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer meterTimer;
        private System.Windows.Forms.NumericUpDown comPortUpDown;
        private System.Windows.Forms.NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.CheckBox connectOnStartupCheckbox;
        private System.Windows.Forms.CheckBox startupInSystemTrayCheckbox;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

