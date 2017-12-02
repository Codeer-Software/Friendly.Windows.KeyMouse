using Codeer.Friendly.Windows.Grasp;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class PopupUtility
    {
        public static void ExecuteContextMenu(IUIObject target, params PopupTarget[] targets)
        {
            var popup = WindowControl.WaitForNextWindow(target.App, () => UIObjectMouseEmulator.Click(target, MouseButtonType.Right));
            ClickPopupTargets(popup, targets);
        }

        public static WindowControl ClickPopupTargets(WindowControl popup, params PopupTarget[] targets)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                var e = targets[i];
                WindowControl.ShowWindowAction click = () => UIObjectMouseEmulator.Click(CoordinateUtility.SplitToRows(popup, e.ItemCount)[e.TargetIndex]);
                if (i == targets.Length - 1)
                {
                    click();
                }
                else
                {
                    popup = WindowControl.WaitForNextWindow(popup.App, click);
                }
            }
            return popup;
        }
    }

    public class PopupTarget
    {
        public int ItemCount { get; }
        public int TargetIndex { get; }
        public PopupTarget(int itemCount, int targetIndex)
        {
            ItemCount = itemCount;
            TargetIndex = targetIndex;
        }
    }
}
