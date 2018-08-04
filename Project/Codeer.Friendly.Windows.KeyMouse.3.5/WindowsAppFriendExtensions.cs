using System.Drawing;
using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// Extension method of WindowsAppFriend.
    /// </summary>
    public static class WindowsAppFriendExtensions
    {
        /// <summary>
        /// Wait for the timer message to be executed inside the target application.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        public static void WaitForTimerMessage(this WindowsAppFriend app) 
            => TimingUtility.WaitForTimerMessage(app);

        /// <summary>
        /// Send keys.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="keys">Keys for sending. It is the same as the rule of System.Windows.Forms.SendKeys.</param>
        public static void SendKeys(this WindowsAppFriend app, string keys)
            => new KeybordEmulator(app).Send(keys);

        /// <summary>
        /// Send key.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="key">key.</param>
        public static void SendKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).Send(key);

        /// <summary>
        /// Ctrl + Key.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="key">key.</param>
        public static void SendControlAndKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).SendControlAnd(key);

        /// <summary>
        /// Shift + Key.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="key">key.</param>
        public static void SendShiftAndKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).SendShiftAnd(key);

        /// <summary>
        /// Alt + Key.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="key">key.</param>
        public static void SendAltAndKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).SendAltAnd(key);

        /// <summary>
        /// Send the key with modify.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="isControl">Is the Ctrl key pressed.</param>
        /// <param name="isShift">Is the Shift key pressed.</param>
        /// <param name="isAlt">Is the Alt key pressed.</param>
        /// <param name="key">key.</param>
        public static void SendModifyAndKey(this WindowsAppFriend app, bool isControl, bool isShift, bool isAlt, Keys key)
            => new KeybordEmulator(app).SendModifyAnd(isControl, isShift, isAlt, key);

        /// <summary>
        /// Key up.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="key">key.</param>
        public static void KeyUp(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).Up(key);

        /// <summary>
        /// Key down.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="key">key.</param>
        public static void KeyDown(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).Down(key);

        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="app">WindowsAppFriend.</param>
        /// <param name="screenLoactaion">Client coordinates.</param>
        public static void MouseMove(this WindowsAppFriend app, Point screenLoactaion)
            => new MouseEmulator(app).Move(screenLoactaion);
    }
}
