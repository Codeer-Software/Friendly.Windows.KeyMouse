using Codeer.Friendly.Windows.Grasp;
using System.Drawing;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class UIObjectExtensions
    {
        public static void SendKeys(this IUIObject obj, string keys)
            => UIObjectKeybordEmulator.SendKeys(obj, keys);

        public static void MouseMove(this IUIObject obj, Point clientLocation)
            => UIObjectMouseEmulator.MouseMove(obj, clientLocation);

        public static void MouseMove(this IUIObject obj, int clientX, int clientY)
            => UIObjectMouseEmulator.MouseMove(obj, clientX, clientY);

        public static void MouseDown(this IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
            => UIObjectMouseEmulator.MouseDown(obj, type, clientLocation);

        public static void MouseDown(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.MouseDown(obj, type, clientX, clientY);

        public static void MouseUp(this IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
            => UIObjectMouseEmulator.MouseUp(obj, type, clientLocation);

        public static void MouseUp(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.MouseUp(obj, type, clientX, clientY);

        public static void Click(this IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
            => UIObjectMouseEmulator.Click(obj, type, clientLocation);

        public static void Click(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.Click(obj, type, clientX, clientY);

        public static void DoubleClick(this IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
            => UIObjectMouseEmulator.DoubleClick(obj, type, clientLocation);

        public static void DoubleClick(this IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => UIObjectMouseEmulator.DoubleClick(obj, type, clientX, clientY);
    }
}
