using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using static NotAKeyloggerInterface.HookStructs;
using static NotAKeyloggerInterface.DllImportFunctions;

namespace NotAKeyloggerInterface
{
    public class UserActivityHook
    {
        // Create handlers
        public event MouseEventHandler OnMouseActivity;
        public event KeyEventHandler KeyDown;
        public event KeyPressEventHandler KeyPress;
        public event KeyEventHandler KeyUp;

        // Set mousehook locs so we are able to unhook again
        private int hMouseHook = 0;
        private int hKeyboardHook = 0;

        // Save hook procedures
        private static HookProc MouseHookProcedure;
        private static HookProc KeyboardHookProcedure;

        // Destructor to make sure the hook gets removed
        ~UserActivityHook()
        {
            Stop(true, true, false);
        }

        // Install all hooks
        public void Start()
        {
            Start(true, true);
        }

        /// <summary>
        /// Start hooks and throw error if fails
        /// </summary>
        /// <param name="InstallMouseHook"> if true; install mouse hook</param>
        /// <param name="InstallKeyboardHook">if true; install keyboard hook</param>
        public void Start(bool InstallMouseHook, bool InstallKeyboardHook)
        {
            if (hMouseHook == 0 && InstallMouseHook)
            {
                MouseHookProcedure = new HookProc(MouseHookProc);
                hMouseHook = SetWindowsHookEx(WindowsConstants.WH_MOUSE_LL,MouseHookProcedure,Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),0);

                if (hMouseHook == 0)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    Stop(true, false, false);
                    throw new Win32Exception(errorCode);
                }
            }

            if (hKeyboardHook == 0 && InstallKeyboardHook)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WindowsConstants.WH_KEYBOARD_LL,KeyboardHookProcedure,Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),0);

                if (hKeyboardHook == 0)
                {
                    //Returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set. 
                    int errorCode = Marshal.GetLastWin32Error();
                    //do cleanup
                    Stop(false, true, false);
                    //Initializes and throws a new instance of the Win32Exception class with the specified error. 
                    throw new Win32Exception(errorCode);
                }
            }
        }

        // Unhook all
        public void Stop()
        {
            Stop(true, true, true);
        }

        /// <summary>
        /// Unhooks all hooked hooks (great sentence)
        /// </summary>
        /// <param name="UninstallMouseHook">if true; unhook mouse hook</param>
        /// <param name="UninstallKeyboardHook">if true; unhook keyboard hook</param>
        /// <param name="ThrowExceptions">if true; throws exeption if fails unhooking </param>
        public void Stop(bool UninstallMouseHook, bool UninstallKeyboardHook, bool ThrowExceptions)
        {
            if (hMouseHook != 0 && UninstallMouseHook)
            {
                int retMouse = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
                if (retMouse == 0 && ThrowExceptions)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode);
                }
            }

            if (hKeyboardHook != 0 && UninstallKeyboardHook)
            {
                int retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
                if (retKeyboard == 0 && ThrowExceptions)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode);
                }
            }
        }

        /// <summary>
        /// Handles when hook is fired (mouse activity detected)
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (OnMouseActivity != null))
            {
                MouseLLHookStruct mouseHookStruct = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

                MouseButtons button = MouseButtons.None;
                short mouseDelta = 0;
                switch (wParam)
                {
                    case WindowsConstants.WM_LBUTTONDOWN:
                        button = MouseButtons.Left;
                        break;
                    case WindowsConstants.WM_RBUTTONDOWN:
                        button = MouseButtons.Right;
                        break;
                    case WindowsConstants.WM_MOUSEWHEEL:
                        mouseDelta = (short)((mouseHookStruct.mouseData >> 16) & 0xffff);
                        break;
                }

                int clickCount = 0;
                if (button != MouseButtons.None)
                    if (wParam == WindowsConstants.WM_LBUTTONDBLCLK || wParam == WindowsConstants.WM_RBUTTONDBLCLK)
                        clickCount = 2;
                    else
                        clickCount = 1;

                MouseEventArgs e = new MouseEventArgs(button,clickCount,mouseHookStruct.pt.x,mouseHookStruct.pt.y,mouseDelta);
                OnMouseActivity(this, e);
            }

            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }

        /// <summary>
        /// Fired when keyboard activity is detected
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            bool handled = false;

            if ((nCode >= 0) && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                if (KeyDown != null && (wParam == WindowsConstants.WM_KEYDOWN || wParam == WindowsConstants.WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDown(this, e);
                    handled = handled || e.Handled;
                }

                if (KeyPress != null && wParam == WindowsConstants.WM_KEYDOWN)
                {
                    bool isDownShift = ((GetKeyState(WindowsConstants.VK_SHIFT) & 0x80) == 0x80 ? true : false);
                    bool isDownCapslock = (GetKeyState(WindowsConstants.VK_CAPITAL) != 0 ? true : false);

                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode,MyKeyboardHookStruct.scanCode,keyState,inBuffer,MyKeyboardHookStruct.flags) == 1)
                    {
                        char key = (char)inBuffer[0];
                        if ((isDownCapslock ^ isDownShift) && char.IsLetter(key)) key = char.ToUpper(key);
                        KeyPressEventArgs e = new KeyPressEventArgs(key);
                        KeyPress(this, e);
                        handled = handled || e.Handled;
                    }
                }

                if (KeyUp != null && (wParam == WindowsConstants.WM_KEYUP || wParam == WindowsConstants.WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUp(this, e);
                    handled = handled || e.Handled;
                }

            }

            if (handled)
                return 1;
            else
                return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
    }
}
