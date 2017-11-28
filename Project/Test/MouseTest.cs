using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows.KeyMouse;
using Codeer.Friendly.Dynamic;
using System.Drawing;

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
            var w = WindowControl.FromZTop(app);
            var l = new WindowControl(w.Dynamic()._clickCheck);
            l.Click(MouseButtonType.Left, new Point(2, 3));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "CheckClick : Left, 2, 3");
            l.Click(MouseButtonType.Middle, new Point(4, 5));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "CheckClick : Middle, 4, 5");
            l.Click(MouseButtonType.Right, new Point(6, 7));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "CheckClick : Right, 6, 7");
        }

        [TestMethod]
        public void TestDoubleClick1()
        {
            var w = WindowControl.FromZTop(app);
            for (int i = 0; i < 5; i++)
            {
                w.DoubleClick();
            }
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "DoubleClick : 5");
            Assert.AreEqual((int)w.Dynamic()._click, 5);
        }

        [TestMethod]
        public void TestDoubleClick2()
        {
            var w = WindowControl.FromZTop(app);
            var l = new WindowControl(w.Dynamic()._clickCheck);
            l.DoubleClick(MouseButtonType.Left, new Point(2, 3));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "CheckDoubleClick : Left, 2, 3");
            l.DoubleClick(MouseButtonType.Middle, new Point(4, 5));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "CheckDoubleClick : Middle, 4, 5");
            l.DoubleClick(MouseButtonType.Right, new Point(6, 7));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "CheckDoubleClick : Right, 6, 7");
        }

        [TestMethod]
        public void TestDrag()
        {
            var w = WindowControl.FromZTop(app);
            var l = new WindowControl(w.Dynamic()._list);
            l.MouseDown(MouseButtonType.Left, new Point(0, 0));
            w.MouseUp(MouseButtonType.Left, new Point(2, 3));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "Drop : 2, 3");
        }

        [TestMethod]
        public void TestMove()
        {
            var w = WindowControl.FromZTop(app);
            var l = new WindowControl(w.Dynamic()._moveCheck);
            l.MouseMove(new Point(3, 4));
            Assert.AreEqual((string)w.Dynamic()._textBox.Text, "Check Move : 3, 4");
        }
    }
}
