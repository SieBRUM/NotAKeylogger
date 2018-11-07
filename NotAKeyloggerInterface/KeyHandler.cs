using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NotAKeyloggerInterface
{
    public class KeyHandler
    {
        // Import Windows dll's
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint theardID);
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref keyBoardHookStruct lParam);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        // Make keyboardhook public
        public delegate int LLKeyboardHook(int Code, int wParam, ref keyBoardHookStruct lParam);

        LLKeyboardHook llkh;
        // Store hooked keys (for current project, use all keys)
        public List<Keys> HookedKeys = new List<Keys>();
        // Make sure this stays null when starting, keeps track of hook to be able to unhook
        IntPtr Hook = IntPtr.Zero;

        // Make sure to trigger the actual event (and not stop it from happening)
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        // Set Windows event trigger values
        const int WM_KEYUP = 0x0101;
        const int WM_SYSKEYUP = 0x0105;
        const int WM_SYSKEYDOWN = 0x0104;
        const int WM_KEYDOWN = 0x0100;
        const int WH_KEYBOARD_LL = 13;

        // Default keyboard hook struct, vkCode is only interesting data though
        public struct keyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public KeyHandler()
        {
            llkh = new LLKeyboardHook(HookProc);

        }
        ~KeyHandler()
        {
            unhook();
        }

        // Start hooking
        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            Hook = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);
        }

        // Remove and unhook
        public void unhook()
        {

            UnhookWindowsHookEx(Hook);
            Hook = IntPtr.Zero;
        }

        // Triggered when key is pressed and trigger functions that init this class 
        public int HookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
        {
            if (Code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs kArg = new KeyEventArgs(key);
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                        KeyDown(this, kArg);
                    else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                        KeyUp(this, kArg);
                    if (kArg.Handled)
                        return 1;
                }
            }

            // Make sure to call the next hook if needed, won't do anything if nothing is queue'd
            return CallNextHookEx(Hook, Code, wParam, ref lParam);
        }
    }
}
