using Codeer.Friendly.Windows.KeyMouse.Inside;
using System.Windows.Forms;
using static Codeer.Friendly.Windows.KeyMouse.Inside.NativeMethods;
using static Codeer.Friendly.Windows.KeyMouse.TimingUtility;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public class KeybordEmulator
    {
        WindowsAppFriend _app;

        public KeybordEmulator(WindowsAppFriend app)
            => _app = TargetAppInitializer.Init(app);

        public void Send(string keys)
        {
            WaitForTimerMessage(_app);
            SendKeys.SendWait(keys);
            WaitForTimerMessage(_app);
        }

        public void SendControlAnd(Keys key)
        {
            Down(Keys.ControlKey);
            Down(key);
            Up(key);
            Up(Keys.ControlKey);
        }

        public void SendShiftAnd(Keys key)
        {
            Down(Keys.ShiftKey);
            Down(key);
            Up(key);
            Up(Keys.ShiftKey);
        }

        public void SendAltAnd(Keys key)
        {
            Down(Keys.Menu);
            Down(key);
            Up(key);
            Up(Keys.Menu);
        }

        public void SendModifyAnd(bool isControl, bool isShift, bool isAlt, Keys key)
        {
            if (isControl) Down(Keys.ControlKey);
            if (isShift) Down(Keys.ShiftKey);
            if (isAlt) Down(Keys.Menu);
            Down(key);
            Up(key);
            if (isAlt) Up(Keys.Menu);
            if (isShift) Up(Keys.ShiftKey);
            if (isControl) Up(Keys.ControlKey);
        }

        public void Down(Keys key)
        {
            WaitForTimerMessage(_app);
            var inputs = new SendInputEx();
            inputs.AddKeyboardInput(KeyboardStroke.KEY_DOWN | KeyboardStroke.KEYEVENTF_EXTENDEDKEY, key);
            inputs.Execute();
            WaitForTimerMessage(_app);
        }

        public void Up(Keys key)
        {
            WaitForTimerMessage(_app);
            var inputs = new SendInputEx();
            inputs.AddKeyboardInput(KeyboardStroke.KEY_UP | KeyboardStroke.KEYEVENTF_EXTENDEDKEY, key);
            inputs.Execute();
            WaitForTimerMessage(_app);
        }
    }
}
