using Codeer.Friendly.Windows.KeyMouse.Inside;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Codeer.Friendly.Windows.KeyMouse.Inside.NativeMethods;
using static Codeer.Friendly.Windows.KeyMouse.Inside.TimingAdjuster;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public class MouseEmulator
    {
        WindowsAppFriend _app;

        public MouseEmulator(WindowsAppFriend app)
            => _app = TargetAppInitializer.Init(app);

        public void Down(MouseButtonType button, bool swing = true)
        {
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
            WaitTimerMessage(_app);
            if (swing)
            {
                Cursor.Position = pos;
            }
        }

        public void Up(MouseButtonType button)
        {
            var inputs = new SendInputEx();
            inputs.AddMouseInput(ToUpStroke(button), 0, true, 0, 0);
            inputs.Execute();
            WaitTimerMessage(_app);
            SetClickTime();
        }

        public void Click(MouseButtonType button)
        {
            WaitForDoubleClickTime();
            
            var inputs = new SendInputEx();
            inputs.AddMouseInput(ToDownStroke(button), 0, true, 0, 0);
            inputs.AddMouseInput(ToUpStroke(button), 0, true, 0, 0);

            inputs.Execute();
            WaitTimerMessage(_app);
            SetClickTime();
        }

        public void DoubleClick(MouseButtonType button)
        {
            WaitForDoubleClickTime();

            var inputs = new SendInputEx();
            for (int i = 0; i < 2; i++)
            {
                inputs.AddMouseInput(ToDownStroke(button), 0, true, 0, 0);
                inputs.AddMouseInput(ToUpStroke(button), 0, true, 0, 0);
            }

            inputs.Execute();
            WaitTimerMessage(_app);
            SetClickTime();
        }

        public void Move(Point pos)
        {
            var inputs = new SendInputEx();
            Cursor.Position = new Point(pos.X, pos.Y);
            WaitTimerMessage(_app);
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
