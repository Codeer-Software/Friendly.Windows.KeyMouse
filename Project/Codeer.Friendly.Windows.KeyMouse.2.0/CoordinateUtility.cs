using System.Drawing;
using Codeer.Friendly.Windows.Grasp;
using System.Collections.Generic;

namespace Codeer.Friendly.Windows.KeyMouse
{
    public static class CoordinateUtility
    {
        public static IUIObject[] SplitToColumns(IUIObject obj, int colCount)
        {
            double colWidth = obj.Size.Width / colCount;
            var list = new List<IUIObject>();
            for (int i = 0; i < colCount; i++)
            {
                list.Add(new SplitedUIObject(obj, (int)(colWidth * i), 0, (int)colWidth, obj.Size.Height));
            }
            return list.ToArray();
        }

        public static IUIObject[] SplitToRows(IUIObject obj, int rowCount)
        {
            double rowHeight = obj.Size.Height / rowCount;
            var list = new List<IUIObject>();
            for (int i = 0; i < rowCount; i++)
            {
                list.Add(new SplitedUIObject(obj, 0, (int)(rowHeight * i), obj.Size.Width, (int)rowHeight));
            }
            return list.ToArray();
        }

        public static IUIObject[][] SplitToGrid(IUIObject obj, int rowCount, int colCount)
        {
            double colWidth = obj.Size.Width / colCount;
            double rowHeight = obj.Size.Height / rowCount;
            var rowList = new List<IUIObject[]>();
            for (int i = 0; i < rowCount; i++)
            {
                var colList = new List<IUIObject>();
                for (int j = 0; j < colCount; j++)
                {
                    colList.Add(new SplitedUIObject(obj, (int)(colWidth * j), (int)(rowHeight * i), (int)colWidth, (int)rowHeight));
                }
                rowList.Add(colList.ToArray());
            }
            return rowList.ToArray();
        }
    }

    class SplitedUIObject : IUIObject
    {
        IUIObject _core;
        Rectangle _clientBounds;

        public SplitedUIObject(IUIObject core, int x, int y, int width, int height)
        {
            _core = core;
            _clientBounds = new Rectangle(x, y, width, height);
        }

        public WindowsAppFriend App => _core.App;

        public Size Size => _clientBounds.Size;

        public void Activate() => _core.Activate();

        public Point PointToScreen(Point clientPoint)
            => _core.PointToScreen(new Point(clientPoint.X + _clientBounds.X, clientPoint.Y + _clientBounds.Y));
    }
}
