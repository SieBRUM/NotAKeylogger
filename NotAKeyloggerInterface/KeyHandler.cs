using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NotAKeyloggerInterface
{
    public class KeyHandler
    {
        // Import Windows dll's
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetWindowsHookEx(int idHook,HookProc lpfn,IntPtr hMod,int dwThreadId);
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref keyBoardHookStruct lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook,int nCode,int wParam,IntPtr lParam);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);


        // Make keyboardhook public
        public delegate int LLKeyboardHook(int Code, int wParam, ref keyBoardHookStruct lParam);
        private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        LLKeyboardHook llkh;
        private static HookProc MouseHookProcedure;
        // Store hooked keys (for current project, use all keys)
        public List<Keys> HookedKeys = new List<Keys>();
        // Make sure this stays null when starting, keeps track of hook to be able to unhook
        IntPtr KeyboardHook = IntPtr.Zero;
        int MouseHook = 0;

        // Make sure to trigger the actual event (and not stop it from happening)
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event MouseEventHandler OnMouseActivity;

        // Set windows low-level monitoring values for keyboard
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYDOWN = 0x0100;
        private const int WH_KEYBOARD_LL = 13;

        // Set windows low-level monitoring values for mouse
        private const int WH_MOUSE_LL = 14;
        private const int WH_MOUSE = 7;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;
        private const int WM_MOUSEWHEEL = 0x020A;

        // Default keyboard hook struct, vkCode is only interesting data though
        public struct keyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        private class POINT
        {
            public int x;
            public int y;
        }

        public KeyHandler()
        {
            llkh = new LLKeyboardHook(KeyboardHookProc);
        }

        ~KeyHandler()
        {
            unhook();
        }

        // Start hooking
        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            KeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);

            // Create an instance of HookProc.
            MouseHookProcedure = new HookProc(MouseHookProc);
            //install hook
            MouseHook = SetWindowsHookEx(WH_MOUSE_LL,MouseHookProcedure,Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),0);
        }

        // Remove and unhook
        public void unhook()
        {

            UnhookWindowsHookEx(KeyboardHook);
            UnhookWindowsHookEx(MouseHook);
            KeyboardHook = IntPtr.Zero;
            MouseHook = 0;
        }

        // Triggered when key is pressed and trigger functions that init this class 
        public int KeyboardHookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
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
            return CallNextHookEx(KeyboardHook, Code, wParam, ref lParam);
        }

        private int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            // if ok and someone listens to our events
            if ((nCode >= 0) && (OnMouseActivity != null))
            {
                //Marshall the data from callback.
                MouseLLHookStruct mouseHookStruct = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

                //detect button clicked
                MouseButtons button = MouseButtons.None;
                short mouseDelta = 0;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                        //case WM_LBUTTONUP: 
                        //case WM_LBUTTONDBLCLK: 
                        button = MouseButtons.Left;
                        break;
                    case WM_RBUTTONDOWN:
                        //case WM_RBUTTONUP: 
                        //case WM_RBUTTONDBLCLK: 
                        button = MouseButtons.Right;
                        break;
                    case WM_MOUSEWHEEL:
                        //If the message is WM_MOUSEWHEEL, the high-order word of mouseData member is the wheel delta. 
                        //One wheel click is defined as WHEEL_DELTA, which is 120. 
                        //(value >> 16) & 0xffff; retrieves the high-order word from the given 32-bit value
                        mouseDelta = (short)((mouseHookStruct.mouseData >> 16) & 0xffff);
                        //TODO: X BUTTONS (I havent them so was unable to test)
                        //If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, 
                        //or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released, 
                        //and the low-order word is reserved. This value can be one or more of the following values. 
                        //Otherwise, mouseData is not used. 
                        break;
                }

                //double clicks
                int clickCount = 0;
                if (button != MouseButtons.None)
                    if (wParam == WM_LBUTTONDBLCLK || wParam == WM_RBUTTONDBLCLK) clickCount = 2;
                    else clickCount = 1;

                //generate event 
                MouseEventArgs e = new MouseEventArgs(button,clickCount,mouseHookStruct.pt.x,mouseHookStruct.pt.y,mouseDelta);
                //raise it
                OnMouseActivity(this, e);
            }
            //call next hook
            return CallNextHookEx(MouseHook, nCode, wParam, lParam);
        }
    }
}
