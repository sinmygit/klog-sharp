using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Klog
{
    /// <summary>
    /// We want to log things like:
    /// [Ctrl]          // by itself
    /// [Ctrl+A+V]      // all simultaneous
    /// [Ctrl+Alt+Del]  // all simultaneous
    /// [Alt+F,C]       // Alt held, then F, C pressed in succession
    /// 
    /// Bug:
    /// - we don't distinguish between "Alt+E+V" (same time) and "Alt+E,V" (consecutive)
    /// </summary>
    public class KeyChord
    {
        bool _completed = false;

        bool _ctrlDown = false;
        bool _altDown = false;
        bool _shiftDown = false;
        bool _winDown = false;

        Keys _lastKeyDown;
        List<Keys> _normalKeys = new List<Keys>();

        String _stringRep = String.Empty;

        public KeyChord() { }

        /// <summary>
        /// Reopen a completed chord
        /// </summary>
        public void Reopen()
        {
            _completed = false;
            _lastKeyDown = Keys.None;
            _normalKeys.Clear();
            _stringRep = String.Empty;
        }

        // Chord is "Started" if any modifiers were pressed
        public bool HasControlKeys { get { return _ctrlDown || _altDown || _winDown; } }
        public bool Completed { get { return _completed; } }

        public event EventHandler ClipboardAction;
        
        public void AddKeyDown(Keys k)
        {
            if (_completed) { throw new InvalidOperationException("Chord completed."); }

            switch (k)
            {
                case Keys.RControlKey:
                case Keys.LControlKey:
                    _ctrlDown = true; break;
                case Keys.LMenu:
                case Keys.RMenu:
                    _altDown = true; break;
                case Keys.RShiftKey:
                case Keys.LShiftKey:
                    _shiftDown = true; break;
                case Keys.RWin:
                case Keys.LWin:
                    _winDown = true; break;
                default:
                    // Add the key
                    if (HasControlKeys && _lastKeyDown != k) 
                    { 
                        _normalKeys.Add(k); 
                    }
                    break;
            }
            _lastKeyDown = k;
        }
        public void AddKeyUp(Keys k)
        {
            if (_completed) { throw new InvalidOperationException("Chord completed."); }

            switch (k)
            {
                case Keys.RControlKey:
                case Keys.LControlKey:
                    CompleteChord();
                    _ctrlDown = false; break;
                case Keys.LMenu:
                case Keys.RMenu:
                    CompleteChord();
                    _altDown = false; break;
                case Keys.RShiftKey:
                case Keys.LShiftKey:
                    CompleteChord();
                    _shiftDown = false; break;
                case Keys.RWin:
                case Keys.LWin:
                    CompleteChord();
                    _winDown = false; break;
                default:
                    if (!HasControlKeys && !IsNormalKey(k))
                    {
                        // TODO: special case for characters
                        _normalKeys.Add(k);
                        CompleteChord();
                    }
                    break;
            }
            _lastKeyDown = Keys.None;
        }

        static bool IsNormalKey(Keys key)
        {
            int k = (int)key;

            return
                (k >= (int)Keys.D0 && k <= (int)Keys.Z) ||
                (k >= (int)Keys.NumPad0 && k <= (int)Keys.Divide) ||
                (k >= (int)Keys.Oem1 && k <= (int)Keys.OemBackslash) || // for some laptop keyboards
                 key == Keys.Space;
        }

        void CompleteChord()
        {
            _completed = true;

            if (_normalKeys.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");

                if (_ctrlDown) { sb.Append("Ctrl+"); }
                if (_altDown) { sb.Append("Alt+"); }
                if (_winDown) { sb.Append("Win+"); }
                if (_shiftDown) { sb.Append("Shift+"); }

                foreach (Keys k in _normalKeys)
                {
                    sb.Append(k.ToString());
                }

                sb.Append("]");
                _stringRep = sb.ToString();

                // Cliboard actions
                // Note: modifiers are OK (sometimes Ctrl+Alt+V, Ctrl+Shift+V etc are paste special 
                // and similar)
                if (_ctrlDown &&
                    _normalKeys.Contains(Keys.V) ||
                    _normalKeys.Contains(Keys.C) ||
                    _normalKeys.Contains(Keys.X))
                {
                    if (ClipboardAction != null) { ClipboardAction(this, EventArgs.Empty); }
                }

            }
        }        

        public override string ToString()
        {
            if (Completed) { return _stringRep; }

            return base.ToString();
        }
    }
}
