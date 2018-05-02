using Codeer.Friendly.Windows.KeyMouse.Inside;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// Utility for taking timing.
    /// </summary>
    public static class TimingUtility
    {
        /// <summary>
        /// Wait for the timer message to be executed inside the target application.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        public static void WaitForTimerMessage(WindowsAppFriend app)
        {
            var waiter = app.Dim(new NewInfo<TimerMessageWaiter>());
            while (!(bool)waiter["Arrived"]().Core) System.Threading.Thread.Sleep(0);
        }
    }
}
