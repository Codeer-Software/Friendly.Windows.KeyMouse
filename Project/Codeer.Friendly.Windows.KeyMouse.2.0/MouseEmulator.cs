using Codeer.Friendly.Windows.KeyMouse.Inside;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Codeer.Friendly.Windows.KeyMouse.Inside.NativeMethods;
using static Codeer.Friendly.Windows.KeyMouse.TimingUtility;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// Mouse emulator.
    /// </summary>
    public class MouseEmulator
    {
        WindowsAppFriend _app;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        public MouseEmulator(WindowsAppFriend app)
            => _app = TargetAppInitializer.Init(app);

        /// <summary>
        /// Mouse down.
        /// </summary>
        /// <param name="button">Mouse button type.</param>
        /// <param name="swing">Flag to decide whether to move the mouse slightly after pressing the mouse button. If it is set to true, the manipulation feeling increases and in many cases it affects the better.</param>
        public void Down(MouseButtonType button, bool swing = true)
        {
            WaitForTimerMessage(_app);
            var pos = Cursor.Position;
            var inputs = new SendInputEx();
            inputs.AddMouseInput(ToDownStroke(button), 0, true, 0, 0);
            if (swing)
            {
                inputs.AddMouseInput(MouseStroke.MOVE, 0, true, pos.X + 1, pos.Y + 1);
                inputs.AddMouseInput(MouseStroke.MOVE, 0, true, pos.X + 0, pos.Y + 0);
                inputs.AddMouseInput(MouseStroke.MOVE, 0, true, pos.X - 1, pos.Y - 1);
                inputs.AddMouseInput(MouseStroke.MOVE, 0, true, pos.X + 0, pos.Y + 0);
            }
            inputs.Execute();
            WaitForTimerMessage(_app);
            if (swing)
            {
                Cursor.Position = pos;
            }
        }

        /// <summary>
        /// Mouse up.
        /// </summary>
        /// <param name="button">Mouse button type.</param>
        public void Up(MouseButtonType button)
        {
            WaitForTimerMessage(_app);
            var inputs = new SendInputEx();
            inputs.AddMouseInput(ToUpStroke(button), 0, true, 0, 0);
            inputs.Execute();
            WaitForTimerMessage(_app);
            SetClickTime();
        }

        /// <summary>
        /// Click.
        /// </summary>
        /// <param name="button">Mouse button type.</param>
        public void Click(MouseButtonType button)
        {
            WaitForTimerMessage(_app);
            WaitForDoubleClickTime();
            
            var inputs = new SendInputEx();
            inputs.AddMouseInput(ToDownStroke(button), 0, true, 0, 0);
            inputs.AddMouseInput(ToUpStroke(button), 0, true, 0, 0);

            inputs.Execute();
            WaitForTimerMessage(_app);
            SetClickTime();
        }

        /// <summary>
        /// Double click.
        /// </summary>
        /// <param name="button">Mouse button type.</param>
        public void DoubleClick(MouseButtonType button)
        {
            WaitForTimerMessage(_app);
            WaitForDoubleClickTime();

            var inputs = new SendInputEx();
            for (int i = 0; i < 2; i++)
            {
                inputs.AddMouseInput(ToDownStroke(button), 0, true, 0, 0);
                inputs.AddMouseInput(ToUpStroke(button), 0, true, 0, 0);
            }

            inputs.Execute();
            WaitForTimerMessage(_app);
            SetClickTime();
        }

        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="screenLocation">Screen coordinates.</param>
        public void Move(Point screenLocation)
        {
            WaitForTimerMessage(_app);
            while ((Point)_app[typeof(Cursor), "Position"]().Core != screenLocation)
            {
                _app[GetType(), "SetCursorPos"](screenLocation);
                WaitForTimerMessage(_app);
            }
        }

        static void SetCursorPos(Point pos)
        {
            if (Cursor.Position == pos) return;

            Cursor.Position = pos;
            while (!PeekMessage(out var msg, IntPtr.Zero, WM_MOUSEMOVE, WM_MOUSEMOVE, PM_NOREMOVE))
            {
                Cursor.Position = pos;
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="near">Whether the direction of wheel of the mouse is toward the near.</param>
        /// <param name="count">Count of wheel.</param>
        public void Wheel(bool near, int count) => Wheel(near ? -120 * count : 120 * count);

        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="delta">delta value.</param>
        public void Wheel(int delta)
        {
            WaitForTimerMessage(_app);

            var inputs = new SendInputEx();
            inputs.AddMouseInput(MouseStroke.WHEEL, delta, false, 0, 0);

            inputs.Execute();
            WaitForTimerMessage(_app);
        }

        void SetClickTime()
        {
            var key = typeof(MouseEmulator).FullName + ":LastClick";
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _app.AddAppControlInfo(key, stopwatch);
        }

        void WaitForDoubleClickTime()
        {
            var key = typeof(MouseEmulator).FullName + ":LastClick";
            if (_app.TryGetAppControlInfo(key, out var value))
            {
                var lastClickTime = (Stopwatch)value;
                lastClickTime.Stop();
                var diff = lastClickTime.ElapsedMilliseconds;
                if (diff < 0)
                {
                    Thread.Sleep(SystemInformation.DoubleClickTime);
                }
                else
                {
                    var waitTime = SystemInformation.DoubleClickTime;
                    if (diff < waitTime)
                    {
                        Debug.WriteLine((int)(waitTime - diff));
                        Thread.Sleep((int)(waitTime - diff));
                    }
                }
            }
        }

        static MouseStroke ToDownStroke(MouseButtonType button)
        {
            switch (button)
            {
                case MouseButtonType.Left: return MouseStroke.LEFT_DOWN;
                case MouseButtonType.Middle: return MouseStroke.MIDDLE_DOWN;
                case MouseButtonType.Right: return MouseStroke.RIGHT_DOWN;
                default: throw new NotSupportedException();
            }
        }

        static MouseStroke ToUpStroke(MouseButtonType button)
        {
            switch (button)
            {
                case MouseButtonType.Left: return MouseStroke.LEFT_UP;
                case MouseButtonType.Middle: return MouseStroke.MIDDLE_UP;
                case MouseButtonType.Right: return MouseStroke.RIGHT_UP;
                default: throw new NotSupportedException();
            }
        }
    }
}
