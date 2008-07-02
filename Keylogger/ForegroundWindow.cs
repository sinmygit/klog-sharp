using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Klog
{
    public class ForegroundWindow
    {
        String _text;
        public String Text { get { return _text; } }

        public bool CheckHasChanged()
        {
            String oldText = _text;
            UpdateText();
            return oldText != _text;
        }

        void UpdateText()
        {
            const int nChars = 512;
            IntPtr handle = GetForegroundWindow();
            StringBuilder buffer = new StringBuilder(nChars);

            if (GetWindowText(handle, buffer, nChars) > 0)
            {
                _text = buffer.ToString();
            }
            else
            {
                _text = "unknown";
            }

            _text = _text + " (" + handle + ")";
        }


        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count); 
    }
}
