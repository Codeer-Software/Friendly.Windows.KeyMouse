using Codeer.Friendly.Windows.Grasp;
using System.Drawing;

namespace Codeer.Friendly.Windows.KeyMouse
{
    /// <summary>
    /// Mouse emulator for IUIObject.
    /// </summary>
    public static class UIObjectMouseEmulator
    {
        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void MouseMove(IUIObject obj, Point clientLocation)
            => new MouseEmulator(obj.App).Move(GetTargetPos(obj, clientLocation));

        /// <summary>
        /// Mouse move.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void MouseMove(IUIObject obj, int clientX, int clientY)
            => MouseMove(obj, new Point(clientX, clientY));

        /// <summary>
        /// Mouse down.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void MouseDown(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.Down(type);
        }

        /// <summary>
        /// Mouse down.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void MouseDown(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => MouseDown(obj, type, new Point(clientX, clientY));

        /// <summary>
        /// Mouse up.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void MouseUp(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.Up(type);
        }

        /// <summary>
        /// Mouse up.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void MouseUp(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => MouseUp(obj, type, new Point(clientX, clientY));

        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="delta">delta value.</param>
        public static void MouseWheel(IUIObject obj, int delta)
        {
            obj.Activate();
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, null));
            mouse.Wheel(delta);
        }

        /// <summary>
        /// Mouse wheel.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="near">Whether the direction of wheel of the mouse is toward the near.</param>
        /// <param name="count">Count of wheel.</param>
        public static void MouseWheel(IUIObject obj, bool near, int count = 1)
        {
            obj.Activate();
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, null));
            mouse.Wheel(near, count);
        }

        /// <summary>
        /// Mouse click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void Click(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.Click(type);
        }

        /// <summary>
        /// Mouse click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
        public static void Click(IUIObject obj, MouseButtonType type, int clientX, int clientY)
            => Click(obj, type, new Point(clientX, clientY));

        /// <summary>
        /// Mouse double click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientLocation">Client coordinates from obj.</param>
        public static void DoubleClick(IUIObject obj, MouseButtonType type = MouseButtonType.Left, Point? clientLocation = null)
        {
            var mouse = new MouseEmulator(obj.App);
            mouse.Move(GetTargetPos(obj, clientLocation));
            mouse.DoubleClick(type);
        }

        /// <summary>
        /// Mouse double click.
        /// </summary>
        /// <param name="obj">IUIObject.</param>
        /// <param name="type">Mouse button type.</param>
        /// <param name="clientX">Client x coordinates from obj.</param>
        /// <param name="clientY">Client y coordinates from obj.</param>
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
