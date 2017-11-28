using System;
using System.Runtime.InteropServices;

namespace Codeer.Friendly.Windows.KeyMouse.Inside
{
    class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct MouseInput
        {
            internal int X;
            internal int Y;
            internal int Data;
            internal int Flags;
            internal int Time;
            internal IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KeyboardInput
        {
            internal short VirtualKey;
            internal short ScanCode;
            internal int Flags;
            internal int Time;
            internal IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HardwareInput
        {
            internal int uMsg;
            internal short wParamL;
            internal short wParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Input
        {
            internal int Type;
            internal InputUnion U;
            internal static int Size
            {
                get { return Marshal.SizeOf(typeof(Input)); }
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion
        {
            [FieldOffset(0)]
            internal MouseInput Mouse;
            [FieldOffset(0)]
            internal KeyboardInput Keyboard;
            [FieldOffset(0)]
            internal HardwareInput Hardware;
        }

        internal enum MouseStroke
        {
            MOVE = 0x0001,
            LEFT_DOWN = 0x0002,
            LEFT_UP = 0x0004,
            RIGHT_DOWN = 0x0008,
            RIGHT_UP = 0x0010,
            MIDDLE_DOWN = 0x0020,
            MIDDLE_UP = 0x0040,
            X_DOWN = 0x0080,
            X_UP = 0x0100,
            WHEEL = 0x0800
        }

        internal enum KeyboardStroke
        {
            KEY_DOWN = 0x0000,
            KEYEVENTF_EXTENDEDKEY = 0x1,
            KEY_UP = 0x0002
        }

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        internal extern static int MapVirtualKey(int wCode, int wMapType);

        [DllImport("user32.dll")]
        internal extern static void SendInput(int nInputs, Input[] pInputs, int cbsize);
    }
}
