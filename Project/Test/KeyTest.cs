using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows.KeyMouse;
using System.Windows.Forms;

namespace Test
{
    [TestClass]
    public class KeyTest
    {
        WindowsAppFriend app;

        [TestInitialize]
        public void TestInitialize()
            => app = new WindowsAppFriend(Process.Start("TestApp.exe"));

        [TestCleanup]
        public void TestCleanup()
            => Process.GetProcessById(app.ProcessId).Kill();

        [TestMethod]
        public void TestSendKey()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._keyTest);

            window.Dynamic()._textBox.Focus();
            var form = app.Type<Form>()();
            form.Show();

            target.SendKeys("abc");
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "abc");
        }

        [TestMethod]
        public void TestKeyUpDown()
        {
            var window = WindowControl.FromZTop(app);
            var target = new WindowControl(window.Dynamic()._keyTest);

            target.SetFocus();
            var keybord = app.Keybord();
            keybord.Down(Keys.ShiftKey);
            keybord.Down(Keys.A);
            keybord.Up(Keys.A);
            keybord.Up(Keys.ShiftKey);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "A");

            keybord.Down(Keys.Menu);
            keybord.Down(Keys.Q);
            keybord.Up(Keys.Q);
            keybord.Up(Keys.Menu);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "ALT + Q");

            keybord.Down(Keys.ControlKey);
            keybord.Down(Keys.Q);
            keybord.Up(Keys.Q);
            keybord.Up(Keys.ControlKey);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "CONTROL + Q");
        }
    }
}
