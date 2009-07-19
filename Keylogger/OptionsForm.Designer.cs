namespace Klog
{
    partial class OptionsForm
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
            if (_hook != null)
            {
                _hook.Stop(true, true, false);
                _hook = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpenControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.cbKeybEnabled = new System.Windows.Forms.CheckBox();
            this.bOpenLog = new System.Windows.Forms.Button();
            this.bChangePassword = new System.Windows.Forms.Button();
            this.tbPass1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPass2 = new System.Windows.Forms.TextBox();
            this.bDeleteLogs = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.cbMouseEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bOpenLogFolder = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.trayContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Klog";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_Click);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenControlPanel});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(179, 26);
            // 
            // menuOpenControlPanel
            // 
            this.menuOpenControlPanel.Name = "menuOpenControlPanel";
            this.menuOpenControlPanel.Size = new System.Drawing.Size(178, 22);
            this.menuOpenControlPanel.Text = "Open Control Panel";
            this.menuOpenControlPanel.Click += new System.EventHandler(this.menuOpenControlPanel_Click);
            // 
            // cbKeybEnabled
            // 
            this.cbKeybEnabled.AutoSize = true;
            this.cbKeybEnabled.Checked = true;
            this.cbKeybEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeybEnabled.Location = new System.Drawing.Point(6, 19);
            this.cbKeybEnabled.Name = "cbKeybEnabled";
            this.cbKeybEnabled.Size = new System.Drawing.Size(154, 17);
            this.cbKeybEnabled.TabIndex = 0;
            this.cbKeybEnabled.Text = "Keyboard Logging Enabled";
            this.cbKeybEnabled.UseVisualStyleBackColor = true;
            this.cbKeybEnabled.CheckedChanged += new System.EventHandler(this.OnUpdateUI);
            // 
            // bOpenLog
            // 
            this.bOpenLog.Location = new System.Drawing.Point(6, 19);
            this.bOpenLog.Name = "bOpenLog";
            this.bOpenLog.Size = new System.Drawing.Size(154, 25);
            this.bOpenLog.TabIndex = 0;
            this.bOpenLog.Text = "Open Main Log File";
            this.bOpenLog.UseVisualStyleBackColor = true;
            this.bOpenLog.Click += new System.EventHandler(this.bOpenLog_Click);
            // 
            // bChangePassword
            // 
            this.bChangePassword.Location = new System.Drawing.Point(113, 71);
            this.bChangePassword.Name = "bChangePassword";
            this.bChangePassword.Size = new System.Drawing.Size(72, 25);
            this.bChangePassword.TabIndex = 2;
            this.bChangePassword.Text = "Change";
            this.bChangePassword.UseVisualStyleBackColor = true;
            this.bChangePassword.Click += new System.EventHandler(this.bChangePassword_Click);
            // 
            // tbPass1
            // 
            this.tbPass1.Location = new System.Drawing.Point(57, 19);
            this.tbPass1.Name = "tbPass1";
            this.tbPass1.PasswordChar = '*';
            this.tbPass1.Size = new System.Drawing.Size(128, 20);
            this.tbPass1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPass2);
            this.groupBox1.Controls.Add(this.tbPass1);
            this.groupBox1.Controls.Add(this.bChangePassword);
            this.groupBox1.Location = new System.Drawing.Point(190, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New:";
            // 
            // tbPass2
            // 
            this.tbPass2.Location = new System.Drawing.Point(57, 45);
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.PasswordChar = '*';
            this.tbPass2.Size = new System.Drawing.Size(128, 20);
            this.tbPass2.TabIndex = 1;
            // 
            // bDeleteLogs
            // 
            this.bDeleteLogs.Location = new System.Drawing.Point(7, 79);
            this.bDeleteLogs.Name = "bDeleteLogs";
            this.bDeleteLogs.Size = new System.Drawing.Size(153, 24);
            this.bDeleteLogs.TabIndex = 2;
            this.bDeleteLogs.Text = "Delete All Logs";
            this.bDeleteLogs.UseVisualStyleBackColor = true;
            this.bDeleteLogs.Click += new System.EventHandler(this.bDeleteLogs_Click);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(12, 212);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(172, 25);
            this.bExit.TabIndex = 3;
            this.bExit.Text = "Quit Klog";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // cbMouseEnabled
            // 
            this.cbMouseEnabled.AutoSize = true;
            this.cbMouseEnabled.Checked = true;
            this.cbMouseEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMouseEnabled.Location = new System.Drawing.Point(6, 42);
            this.cbMouseEnabled.Name = "cbMouseEnabled";
            this.cbMouseEnabled.Size = new System.Drawing.Size(141, 17);
            this.cbMouseEnabled.TabIndex = 1;
            this.cbMouseEnabled.Text = "Mouse Logging Enabled";
            this.cbMouseEnabled.UseVisualStyleBackColor = true;
            this.cbMouseEnabled.CheckedChanged += new System.EventHandler(this.OnUpdateUI);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbKeybEnabled);
            this.groupBox2.Controls.Add(this.cbMouseEnabled);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bOpenLogFolder);
            this.groupBox3.Controls.Add(this.bOpenLog);
            this.groupBox3.Controls.Add(this.bDeleteLogs);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 117);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log Files";
            // 
            // bOpenLogFolder
            // 
            this.bOpenLogFolder.Location = new System.Drawing.Point(6, 49);
            this.bOpenLogFolder.Name = "bOpenLogFolder";
            this.bOpenLogFolder.Size = new System.Drawing.Size(154, 25);
            this.bOpenLogFolder.TabIndex = 1;
            this.bOpenLogFolder.Text = "Open Log Folder";
            this.bOpenLogFolder.UseVisualStyleBackColor = true;
            this.bOpenLogFolder.Click += new System.EventHandler(this.bOpenLogFolder_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.bClose_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 247);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Klog Control Panel";
            this.Deactivate += new System.EventHandler(this.OptionsForm_Deactivate);
            this.Activated += new System.EventHandler(this.OptionsForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.trayContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.CheckBox cbKeybEnabled;
        private System.Windows.Forms.Button bOpenLog;
        private System.Windows.Forms.Button bChangePassword;
        private System.Windows.Forms.TextBox tbPass1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bDeleteLogs;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.CheckBox cbMouseEnabled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPass2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bOpenLogFolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpenControlPanel;
    }
}

