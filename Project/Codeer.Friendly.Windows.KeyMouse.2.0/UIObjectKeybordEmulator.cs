using Codeer.Friendly.Windows.Grasp;
using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// Keybord emulator for IUIObject.
    /// </summary>
    public static class UIObjectKeybordEmulator
    {
        /// <summary>
        /// Send the keys.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="keys">Keys for sending. It is the same as the rule of System.Windows.Forms.SendKeys.</param>
        public static void Send(IUIObject obj, string keys)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).Send(keys);
        }
        /// <summary>
        /// Send the key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void Send(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).Send(key);
        }
        /// <summary>
        /// Ctrl + Key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendControlAnd(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendControlAnd(key);
        }
        /// <summary>
        /// Shift + Key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendShiftAnd(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendShiftAnd(key);
        }

        /// <summary>
        /// Alt + Key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendAltAnd(IUIObject obj, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendAltAnd(key);
        }

        /// <summary>
        /// Send the key with modify.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="isControl">Is the Ctrl key pressed.</param>
        /// <param name="isShift">Is the Shift key pressed.</param>
        /// <param name="isAlt">Is the Alt key pressed.</param>
        /// <param name="key">key.</param>
        public static void SendModifyAnd(IUIObject obj, bool isControl, bool isShift, bool isAlt, Keys key)
        {
            obj.Activate();
            new KeybordEmulator(obj.App).SendModifyAnd(isControl, isShift, isAlt, key);
        }
    }
}