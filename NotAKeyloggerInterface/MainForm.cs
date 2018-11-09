using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotAKeyloggerInterface
{
    public partial class MainForm : Form
    {
        private UserActivityHook UserActivitySpy;
        private string currentWord = "";
        private Dictionary<string, int> Keystrokes;
        private Dictionary<string, int> Words;

        public MainForm()
        {
            InitializeComponent();
            Keystrokes = new Dictionary<string, int>();
            Words = new Dictionary<string, int>();
            UpdateChart();
        }

        ~MainForm()
        {
            // Make sure to unhook the logger, already happens in destructor of keyhook, but can never be sure enough...
            UserActivitySpy.Stop();
        }

        private void InitializeHooks(object sender, EventArgs e)
        {
            UserActivitySpy = new UserActivityHook();
            UserActivitySpy.KeyUp += new KeyEventHandler(ModifierKeysKeyUp);
            UserActivitySpy.KeyDown += new KeyEventHandler(NormalKeysKeyDown);
            UserActivitySpy.OnMouseActivity += new MouseEventHandler(MouseMovement);
        }

        // This is triggered for "special" keys like ctrl shift. Make sure to trigger these only when key-upping. 
        private void ModifierKeysKeyUp(object sender, KeyEventArgs e)
        {
            string getCharVar = ModifierKeyToHumanReadable(e.KeyValue);
            if (getCharVar != null)
            {
                rtbKeylogger.Text += getCharVar;
                WriteKeystrokesToDictionary(getCharVar);
            }
        }
        // This is triggered for the rest of the keys (mostly non-modifier keys)
        private void NormalKeysKeyDown(object sender, KeyEventArgs e)
        {
            string getCharVar = KeyDownHandler(e.KeyValue);
            if (getCharVar != null)
            {
                rtbKeylogger.Text += getCharVar;
                WriteKeystrokesToDictionary(getCharVar);
            }
        }

        private void MouseMovement(object sender, MouseEventArgs e)
        {
            lblMouseLocation.Text = string.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
            lblButtonPressed.Text = $"Button pressed: {e.Button}";
        }

        // Toggle keylogging hook
        private void ToggleLoggingHook(object sender, EventArgs e)
        {
            //Start the KeyboardHook
            if (tsmiToggleLogging.Text == "Start logging")
            {
                UserActivitySpy.Start();
                tsmiToggleLogging.Text = "Stop logging";
            }
            else
            {
                UserActivitySpy.Stop();
                tsmiToggleLogging.Text = "Start logging";
                lblMouseLocation.Text = "Mouse not hooked!";
                lblButtonPressed.Text = "Mouse not hooked!";
            }
        }

        // Make sure the modifier keys are human readable
        private string ModifierKeyToHumanReadable(int Value)
        {
            switch (Value)
            {
                case 8:
                    return "";
                case 9:
                    return "[Tab]";
                case 13:
                    return "\n";
                case 160:
                    return "[Shift]";
                case 162:
                    return "[CTRL]";
                case 164:
                    return "[Alt]";
                case 20:
                    if (IsKeyLocked(Keys.CapsLock))
                        return "[Caps Lock ON]";
                    else
                        return "[Caps Lock OFF]";
                case 32:
                    return " ";
                case 46:
                    return "";
                case 163:
                    return "[R_Alt]";
                case 165:
                    return "[R_Ctrl]";
                default:
                    return null;
            }
        }

        private string KeyDownHandler(int Value)
        {
            // If between those values, numpad is pressed. When removing 48, it will use the "normal" keyboard numberss
            if (Value > 95 && Value < 106)
                return ((char)(Value - 48)).ToString();
            
            // Normal alphabet
            if (Value > 64 && Value < 91)
            {
                if (!IsKeyLocked(Keys.CapsLock))
                    return ((char)(Value + 32)).ToString();
                else
                    return ((char)(Value)).ToString();
            }
            // D keys
            if (Value > 47 && Value < 58)
                return ((char)Value).ToString();

            return null;
        }

        private void WriteKeystrokesToDictionary(string key)
        {
            if(key == " ")
            {
                if (Words.ContainsKey(currentWord))
                {
                    Words[currentWord]++;
                }
                else
                {
                    Words.Add(currentWord, 1);
                }

                currentWord = "";
            }
            else
            {
                currentWord += key;
            }

            if (Keystrokes.ContainsKey(key))
            {
                Keystrokes[key]++;
            }
            else
            {
                Keystrokes.Add(key, 1);
            }

            UpdateChart();
        }

        private void UpdateChart()
        {
            cKeystrokes.Series["Keystrokes"].Points.DataBindXY(Keystrokes.Keys, Keystrokes.Values);
            cKeystrokes.Series["Keystrokes"].Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Descending);
            cKeystrokes.Series["Words"].Points.DataBindXY(Words.Keys, Words.Values);
            cKeystrokes.Series["Words"].Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Descending);
        }
    }
}
