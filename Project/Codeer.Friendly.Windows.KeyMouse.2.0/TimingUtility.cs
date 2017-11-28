using Codeer.Friendly.Windows.KeyMouse.Inside;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class TimingUtility
    {
        public static void WaitForTimerMessage(WindowsAppFriend app)
        {
            var waiter = app.Dim(new NewInfo<TimerMessageWaiter>());
            while (!(bool)waiter["Arrived"]().Core) System.Threading.Thread.Sleep(0);
        }
    }
}
