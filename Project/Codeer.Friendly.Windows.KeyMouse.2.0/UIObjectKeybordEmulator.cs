using Codeer.Friendly.Windows.Grasp;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class UIObjectKeybordEmulator
    {
        public static void SendKeys(IUIObject obj, string keys)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).Send(keys);
        }
    }
}