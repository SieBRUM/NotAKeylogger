using System.Runtime.InteropServices;

/// <summary>
/// This class contains all structs that are needed to get the hook functioning correctly
/// </summary>
namespace NotAKeyloggerInterface
{
    public class HookStructs
    {
        [StructLayout(LayoutKind.Sequential)]
        public class MouseLocation
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public MouseLocation pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseLLHookStruct
        {
            public MouseLocation pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
    }
}
