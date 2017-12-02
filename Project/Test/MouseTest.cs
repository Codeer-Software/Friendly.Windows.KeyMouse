using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows.KeyMouse;
using Codeer.Friendly.Dynamic;
using System.Drawing;
using System.Threading;

namespace Test
{
    [TestClass]
    public class MouseTest
    {
        WindowsAppFriend app;

        [TestInitialize]
        public void TestInitialize()
            => app = new WindowsAppFriend(Process.Start("TestApp.exe"));

        [TestCleanup]
        public void TestCleanup()
            => Process.GetProcessById(app.ProcessId).Kill();

        [TestMethod]
        public void TestClick1()
        {
            var w = WindowControl.FromZTop(app);
            for (int i = 0; i < 5; i++)
            {
                w.Click();
            }
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "Click : 5");
            Assert.AreEqual((int)w.Dynamic()._doubleClick, 0);
        }

        [TestMethod]
        public void TestClick2()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._clickCheck);
            target.Click(MouseButtonType.Left, new Point(2, 3));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "CheckClick : Left, 2, 3");
            target.Click(MouseButtonType.Middle, new Point(4, 5));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "CheckClick : Middle, 4, 5");
            target.Click(MouseButtonType.Right, new Point(6, 7));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "CheckClick : Right, 6, 7");
        }

        [TestMethod]
        public void TestDoubleClick1()
        {
            var window = WindowControl.FromZTop(app);
            for (int i = 0; i < 5; i++)
            {
                window.DoubleClick();
            }
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "DoubleClick : 5");
            Assert.AreEqual((int)window.Dynamic()._click, 5);
        }

        [TestMethod]
        public void TestDoubleClick2()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._clickCheck);
            target.DoubleClick(MouseButtonType.Left, new Point(2, 3));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "CheckDoubleClick : Left, 2, 3");
            target.DoubleClick(MouseButtonType.Middle, new Point(4, 5));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "CheckDoubleClick : Middle, 4, 5");
            target.DoubleClick(MouseButtonType.Right, new Point(6, 7));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "CheckDoubleClick : Right, 6, 7");
        }

        [TestMethod]
        public void TestDrag()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._list);
            target.MouseDown(MouseButtonType.Left, new Point(0, 0));
            window.MouseUp(MouseButtonType.Left, new Point(2, 3));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "Drop : 2, 3");
        }

        [TestMethod]
        public void TestMove()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._moveCheck);
            target.MouseMove(new Point(3, 4));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "Check Move : 3, 4");
        }

        [TestMethod]
        public void TestSplitToRows()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._panel);
            var grid = target.SplitToRows(3);
            grid[2].Click();
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "{X=80,Y=100}");
        }

        [TestMethod]
        public void TestSplitToColumns()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._panel);
            var grid = target.SplitToColumns(4);
            grid[3].Click();
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "{X=140,Y=60}");
        }

        [TestMethod]
        public void TestSplitToGrid()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._panel);
            var grid = target.SplitToGrid(3, 4);
            grid[2][3].Click();
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "{X=140,Y=100}");
        }

        [TestMethod]
        public void TestPopup()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._popupCheck);
            PopupUtility.ExecuteContextMenu(target, new PopupTarget(5, 4), new PopupTarget(5, 4));
            Assert.AreEqual((string)window.Dynamic()._textBox.Text, "Menu10");
        }
    }
}
