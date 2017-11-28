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

            target.SendKeys("aBc");
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "aBc");
        }

        [TestMethod]
        public void TestKeyUpDown()
        {
            var window = WindowControl.FromZTop(app);
            window.Dynamic()._isModeifyTest = true;
            var target = new WindowControl(window.Dynamic()._keyTest);

            target.SetFocus();

            //SHIFT + A
            var keybord = app.Keybord();
            keybord.Down(Keys.ShiftKey);
            keybord.Down(Keys.A);
            keybord.Up(Keys.A);
            keybord.Up(Keys.ShiftKey);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "A");

            //ALT + Q
            keybord.Down(Keys.Menu);
            keybord.Down(Keys.Q);
            keybord.Up(Keys.Q);
            keybord.Up(Keys.Menu);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "ALT + Q");

            //CONTROL + Q
            keybord.Down(Keys.ControlKey);
            keybord.Down(Keys.Q);
            keybord.Up(Keys.Q);
            keybord.Up(Keys.ControlKey);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "CONTROL + Q");
        }

        [TestMethod]
        public void TestModifySend1()
        {
            var window = WindowControl.FromZTop(app);
            window.Dynamic()._isModeifyTest = true;
            var target = new WindowControl(window.Dynamic()._keyTest);

            //SHIFT + A
            target.SendShiftAndKey(Keys.A);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "A");

            //ALT + Q
            target.SendAltAndKey(Keys.Q);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "ALT + Q");

            //CONTROL + Q
            target.SendControlAndKey(Keys.Q);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "CONTROL + Q");
        }

        [TestMethod]
        public void TestModifySend2()
        {
            var window = WindowControl.FromZTop(app);
            window.Dynamic()._isModeifyTest = true;
            var target = new WindowControl(window.Dynamic()._keyTest);

            //SHIFT + A
            target.SendModifyAndKey(false, true, false, Keys.A);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "A");

            //ALT + Q
            target.SendModifyAndKey(false, false, true, Keys.Q);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "ALT + Q");

            //CONTROL + Q
            target.SendModifyAndKey(true, false, false, Keys.Q);
            Assert.AreEqual((string)window.Dynamic()._keyTest.Text, "CONTROL + Q");
        }
    }
}
