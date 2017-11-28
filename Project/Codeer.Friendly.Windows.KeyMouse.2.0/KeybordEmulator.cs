using Codeer.Friendly.Windows.KeyMouse.Inside;
using System.Windows.Forms;
using static Codeer.Friendly.Windows.KeyMouse.Inside.NativeMethods;
using static Codeer.Friendly.Windows.KeyMouse.Inside.TimingAdjuster;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public class KeybordEmulator
    {
        WindowsAppFriend _app;

        public KeybordEmulator(WindowsAppFriend app)
            => _app = TargetAppInitializer.Init(app);

        public void Send(string keys)
        {
            SendKeys.SendWait(keys);
            WaitTimerMessage(_app);
        }

        public void Up(Keys key)
        {
            var inputs = new SendInputEx();
            inputs.AddKeyboardInput(KeyboardStroke.KEY_UP | KeyboardStroke.KEYEVENTF_EXTENDEDKEY, key);
            inputs.Execute();
            WaitTimerMessage(_app);
        }

        public void Down(Keys key)
        {
            var inputs = new SendInputEx();
            inputs.AddKeyboardInput(KeyboardStroke.KEY_DOWN | KeyboardStroke.KEYEVENTF_EXTENDEDKEY, key);
            inputs.Execute();
            WaitTimerMessage(_app);
        }
    }
}
