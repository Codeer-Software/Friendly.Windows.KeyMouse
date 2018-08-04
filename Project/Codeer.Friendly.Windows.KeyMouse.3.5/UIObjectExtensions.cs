using Codeer.Friendly.Windows.Grasp;
using System.Drawing;
using System.Windows.Forms;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// Extension method of IUIObject.
    /// </summary>
    public static class UIObjectExtensions
    {
        /// <summary>
        /// Send the keys.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="keys">Keys for sending. It is the same as the rule of System.Windows.Forms.SendKeys.</param>
        public static void SendKeys(this IUIObject obj, string keys)
            => UIObjectKeybordEmulator.Send(obj, keys);

        /// <summary>
        /// Send the key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendKey(this IUIObject obj, Keys key)
            => UIObjectKeybordEmulator.Send(obj, key);

        /// <summary>
        /// Ctrl + Key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendControlAndKey(this IUIObject obj, Keys key) 
            => UIObjectKeybordEmulator.SendControlAnd(obj, key);

        /// <summary>
        /// Shift + Key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendShiftAndKey(this IUIObject obj, Keys key)
            => UIObjectKeybordEmulator.SendShiftAnd(obj, key);

        /// <summary>
        /// Alt + Key.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="key">key.</param>
        public static void SendAltAndKey(this IUIObject obj, Keys key) 
            => UIObjectKeybordEmulator.SendAltAnd(obj, key);

        /// <summary>
        /// Send the key with modify.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="isControl">Is the Ctrl key pressed.</param>
        /// <param name="isShift">Is the Shift key pressed.</param>
        /// <param name="isAlt">Is the Alt key pressed.</param>
        /// <param name="key">key.</param>
        public static void SendModifyAndKey(this IUIObject obj, bool isControl, bool isShift, bool isAlt, Keys key)
            => UIObjectKeybordEmulator.SendModifyAnd(obj, isControl, isShift, isAlt, key);

        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void MouseMove(this IUIObject obj, Point clientLocation)
            => UIObjectMouseEmulator.MouseMove(obj, clientLocation);

        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void MouseMove(this IUIObject obj, int clientX, int clientY)
            => UIObjectMouseEmulator.MouseMove(obj, clientX, clientY);

        /// <summary>
        /// Mouse down.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void MouseDown(this IUIObject obj, MouseButtonType type, Point? clientLocation = null)
            => UIObjectMouseEmulator.MouseDown(obj, type, clientLocation);

        /// <summary>
        /// Mouse down.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void MouseDown(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.MouseDown(obj, type, clientX, clientY);

        /// <summary>
        /// Mouse up.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void MouseUp(this IUIObject obj, MouseButtonType type, Point? clientLocation = null)
            => UIObjectMouseEmulator.MouseUp(obj, type, clientLocation);

        /// <summary>
        /// Mouse up.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void MouseUp(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.MouseUp(obj, type, clientX, clientY);

        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="delta">delta value.</param>
        public static void MouseWheel(this IUIObject obj, int delta)
            => UIObjectMouseEmulator.MouseWheel(obj, delta);

        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="near">Whether the direction of wheel of the mouse is toward the near.</param>
        /// <param name="count">Count of wheel.</param>
        public static void MouseWheel(this IUIObject obj, bool near, int count = 1)
            => UIObjectMouseEmulator.MouseWheel(obj, near, count);

        /// <summary>
        /// Mouse click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void Click(this IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
            => UIObjectMouseEmulator.Click(obj, type, clientLocation);

        /// <summary>
        /// Mouse click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void Click(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.Click(obj, type, clientX, clientY);

        /// <summary>
        /// Mouse double click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void DoubleClick(this IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
            => UIObjectMouseEmulator.DoubleClick(obj, type, clientLocation);

        /// <summary>
        /// Mouse double click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void DoubleClick(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.DoubleClick(obj, type, clientX, clientY);
    }
}
