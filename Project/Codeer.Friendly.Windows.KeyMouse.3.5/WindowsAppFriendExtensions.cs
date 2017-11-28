namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class WindowsAppFriendExtensions
    {
        public static MouseEmulator Mouse(this WindowsAppFriend app) => new MouseEmulator(app);
        public static KeybordEmulator Keybord(this WindowsAppFriend app) => new KeybordEmulator(app);
        public static void WaitForTimerMessage(this WindowsAppFriend app) => TimingUtility.WaitForTimerMessage(app);
    }
}
