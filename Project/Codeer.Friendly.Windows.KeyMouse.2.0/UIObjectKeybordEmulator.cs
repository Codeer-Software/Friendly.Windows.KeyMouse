using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class UIObjectKeybordEmulator
    {
        public static void Send(IUIObject obj, string keys)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).Send(keys);
        }

        public static void SendControlAnd(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendControlAnd(key);
        }

        public static void SendShiftAnd(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendShiftAnd(key);
        }

        public static void SendAltAnd(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendAltAnd(key);
        }

        public static void SendModifyAnd(IUIObject obj, bool isControl, bool isShift, bool isAlt, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendModifyAnd(isControl, isShift, isAlt, key);
        }
    }
}