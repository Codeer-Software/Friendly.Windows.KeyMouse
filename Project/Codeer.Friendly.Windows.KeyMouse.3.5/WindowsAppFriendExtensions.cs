using System.Drawing;
using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class WindowsAppFriendExtensions
    {
        public static void WaitForTimerMessage(this WindowsAppFriend app) 
            => TimingUtility.WaitForTimerMessage(app);

        public static void SendKeys(this WindowsAppFriend app, string keys)
            => new KeybordEmulator(app).Send(keys);

        public static void SendControlAndKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).SendControlAnd(key);

        public static void SendShiftAndKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).SendShiftAnd(key);

        public static void SendAltAndKey(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).SendAltAnd(key);

        public static void SendModifyAndKey(this WindowsAppFriend app, bool isControl, bool isShift, bool isAlt, Keys key)
            => new KeybordEmulator(app).SendModifyAnd(isControl, isShift, isAlt, key);

        public static void KeyUp(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).Up(key);

        public static void KeyDown(this WindowsAppFriend app, Keys key)
            => new KeybordEmulator(app).Down(key);

        public static void MouseMove(this WindowsAppFriend app, Point screenLoactaion)
            => new MouseEmulator(app).Move(screenLoactaion);
    }
}
