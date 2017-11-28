namespace Codeer.Friendly.Windows.KeyMouse.Inside
{
    static class TimingAdjuster
    {
        internal static void WaitTimerMessage(WindowsAppFriend app)
        {
            var waiter = app.Dim(new NewInfo<TimerMessageWaiter>());
            while (!(bool)waiter["Arrived"]().Core) System.Threading.Thread.Sleep(0);
        }
    }
}
