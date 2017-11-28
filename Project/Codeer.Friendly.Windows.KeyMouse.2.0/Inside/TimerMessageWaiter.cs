using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse.Inside
{
    public class TimerMessageWaiter
    {
        public bool Arrived { get; set; }
        public TimerMessageWaiter()
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
