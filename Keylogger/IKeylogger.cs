using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Klog
{
    /// <summary>
    /// Handles the keylogging events. Responsible for actual filtering / logging of
    /// events that are received from the system.
    /// </summary>
    interface IKeylogger
    {
        void OnKeyUp(object sender, KeyEventArgs e);
        void OnKeyDown(object sender, KeyEventArgs e);
        void OnKeyPress(object sender, KeyPressEventArgs e);
        void OnMouseActivity(object sender, MouseEventArgs e);
    }
}
