using Codeer.Friendly.Windows.KeyMouse.Inside;
using System.Windows.Forms;
using static Codeer.Friendly.Windows.KeyMouse.Inside.NativeMethods;
using static Codeer.Friendly.Windows.KeyMouse.TimingUtility;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// 
    /// </summary>
    public class KeybordEmulator
    {
        WindowsAppFriend _app;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        public KeybordEmulator(WindowsAppFriend app)
            => _app = TargetAppInitializer.Init(app);

        /// <summary>
        /// Send keys.
        /// </summary>
        /// <param name="keys">Keys for sending. It is the same as the rule of System.Windows.Forms.SendKeys.</param>
        public void Send(string keys)
        {
            WaitForTimerMessage(_app);
            SendKeys.SendWait(keys);
            WaitForTimerMessage(_app);
        }

        /// <summary>
        /// Ctrl + Key.
        /// </summary>
        /// <param name="key">key.</param>
        public void SendControlAnd(Keys key)
        {
            Down(Keys.ControlKey);
            Down(key);
            Up(key);
            Up(Keys.ControlKey);
        }

        /// <summary>
        /// Shift + Key.
        /// </summary>
        /// <param name="key">key.</param>
        public void SendShiftAnd(Keys key)
        {
            Down(Keys.ShiftKey);
            Down(key);
            Up(key);
            Up(Keys.ShiftKey);
        }

        /// <summary>
        /// Alt + Key.
        /// </summary>
        /// <param name="key">key.</param>
        public void SendAltAnd(Keys key)
        {
            Down(Keys.Menu);
            Down(key);
            Up(key);
            Up(Keys.Menu);
        }

        /// <summary>
        /// Send the key with modify.
        /// </summary>
        /// <param name="isControl">Is the Ctrl key pressed.</param>
        /// <param name="isShift">Is the Shift key pressed.</param>
        /// <param name="isAlt">Is the Alt key pressed.</param>
        /// <param name="key">key.</param>
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

        /// <summary>
        /// Key down.
        /// </summary>
        /// <param name="key">key.</param>
        public void Down(Keys key)
        {
            WaitForTimerMessage(_app);
            var inputs = new SendInputEx();
            inputs.AddKeyboardInput(KeyboardStroke.KEY_DOWN | KeyboardStroke.KEYEVENTF_EXTENDEDKEY, key);
            inputs.Execute();
            WaitForTimerMessage(_app);
        }

        /// <summary>
        /// Key up.
        /// </summary>
        /// <param name="key">key.</param>
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
