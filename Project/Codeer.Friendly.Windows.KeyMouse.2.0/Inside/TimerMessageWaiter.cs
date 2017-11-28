using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse.Inside
{
    class TimerMessageWaiter
    {
        internal bool Arrived { get; set; }
        internal TimerMessageWaiter()
        {
            var timer = new Timer { Interval = 1 };
            timer.Tick += (_, __) =>
            {
                timer.Stop();
                Arrived = true;
            };
            timer.Start();
        }
    }
}
