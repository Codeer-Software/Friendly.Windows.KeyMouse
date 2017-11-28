using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Codeer.Friendly.Windows.KeyMouse.Inside.NativeMethods;

namespace Codeer.Friendly.Windows.KeyMouse.Inside
{
    internal class SendInputEx
    {
        List<Input> _inputs = new List<Input>();

        internal void AddMouseInput(MouseStroke flag, int data, bool absolute, int x, int y)
        {
            int mouseFlags = (int)flag;

            if (absolute)
            {
                // ABSOLUTE = 0x8000
                mouseFlags |= 0x8000;

                x = ((x * 65535) / Screen.PrimaryScreen.Bounds.Width) + 1;
                y = ((y * 65535) / Screen.PrimaryScreen.Bounds.Height) + 1;
            }

            Input input = new Input();
            input.Type = 0; // MOUSE = 0
            input.U.Mouse.Flags = mouseFlags;
            input.U.Mouse.Data = data;
            input.U.Mouse.X = x;
            input.U.Mouse.Y = y;
            input.U.Mouse.Time = 0;
            input.U.Mouse.ExtraInfo = IntPtr.Zero;

            _inputs.Add(input);
        }

        internal void AddKeyboardInput(KeyboardStroke flags, Keys key)
        {
            int keyboardFlags = (int)flags | 0x0004; //KBD_UNICODE = 0x0004
            short virtualKey = (short)key;
            short scanCode = (short)NativeMethods.MapVirtualKey(virtualKey, 0);

            Input input = new Input();
            input.Type = 1; // KEYBOARD = 1
            input.U.Keyboard.Flags = keyboardFlags;
            input.U.Keyboard.VirtualKey = virtualKey;
            input.U.Keyboard.ScanCode = scanCode;
            input.U.Keyboard.Time = 0;
            input.U.Keyboard.ExtraInfo = IntPtr.Zero;

            _inputs.Add(input);
        }

        internal void Execute()
        {
            Input[] inputArray = _inputs.ToArray();
            SendInput(inputArray.Length, inputArray, Marshal.SizeOf(inputArray[0]));
            _inputs.Clear();
        }
    }
}
