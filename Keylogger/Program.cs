using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Klog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // not showing the form, just creating it
            OptionsForm form = new OptionsForm();
            Application.Run();
        }
    }
}