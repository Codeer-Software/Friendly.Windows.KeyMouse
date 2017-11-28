using Codeer.Friendly.Windows.Grasp;
using System.Drawing;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class UIObjectMouseEmulator
    {
        public static void MouseMove(IUIObject obj, Point clientLocation)
            => new MouseEmulator(obj.App).Move(GetTargetPos(obj, clientLocation));

        public static void MouseMove(IUIObject obj, int clientX, int clientY)
            => MouseMove(obj, new Point(clientX, clientY));

        public static void MouseDown(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.Down(type);
        }

        public static void MouseDown(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => MouseDown(obj, type, new Point(clientX, clientY));

        public static void MouseUp(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.Up(type);
        }

        public static void MouseUp(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => MouseUp(obj, type, new Point(clientX, clientY));

        public static void Click(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.Click(type);
        }

        public static void Click(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => Click(obj, type, new Point(clientX, clientY));

        public static void DoubleClick(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.DoubleClick(type);
        }

        public static void DoubleClick(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => DoubleClick(obj, type, new Point(clientX, clientY));

        static Point GetTargetPos(IUIObject obj, Point? clientLocation)
        {
            Point pos;
            if (clientLocation == null)
            {
                var size = obj.Size;
                pos = new Point(size.Width / 2, size.Height / 2);
            }
            else
            {
                pos = clientLocation.Value;
            }
            pos = obj.PointToScreen(pos);
            return pos;
        }
    }
}
