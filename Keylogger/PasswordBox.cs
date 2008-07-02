using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Klog
{
    public partial class PasswordBox : Form
    {
        public PasswordBox()
        {
            InitializeComponent();
        }

        public String Password { get { return tbPassword.Text; } }
    }
}