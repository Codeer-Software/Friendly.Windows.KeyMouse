using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using System.Diagnostics;
using System.Reflection;
using Codeer.Friendly.Windows.KeyMouse;

namespace TestNetCore
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            WindowsAppFriend.SetCustomSerializer<CustomSerializer>();

            var targetPath = Path.GetFullPath(@"../../../../WinFormsApp/bin/Debug/net8.0-windows/WinFormsApp.exe");
            var info = new ProcessStartInfo(targetPath) { WorkingDirectory = Path.GetDirectoryName(targetPath) };
            var app = new WindowsAppFriend(Process.Start(info));

            var form = app.WaitForIdentifyFromTypeFullName("WinFormsApp.MainForm");
            form.Activate();
            var button = new WindowControl(form.Dynamic()._button);
            button.Click();
            var dlg = form.WaitForNextModal();
            dlg.IdentifyFromWindowText("OK").Click();

            var text = new WindowControl(form.Dynamic()._textBox);
            text.SendKeys("abc");

            text.SendControlAndKey(Keys.A);
            text.SendControlAndKey(Keys.C);
            text.SendKey(Keys.Right);
            text.SendKey(Keys.Right);
            text.SendKey(Keys.Right);

            text.SendControlAndKey(Keys.V);

            Assert.AreEqual(text.GetWindowText(), "abcabc");

            form.Close(new Async());
        }

        public class IntPtrFormatter : IMessagePackFormatter<IntPtr>
        {
            public void Serialize(ref MessagePackWriter writer, IntPtr value, MessagePackSerializerOptions options)
                => writer.Write(value.ToInt64());

            public IntPtr Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
                => new IntPtr(reader.ReadInt64());
        }

        public class CustomSerializer : ICustomSerializer
        {
            MessagePackSerializerOptions customOptions = MessagePackSerializerOptions
                .Standard
                .WithResolver(
                    CompositeResolver.Create(
                        new IMessagePackFormatter[] { new IntPtrFormatter() },
                        new IFormatterResolver[] { TypelessContractlessStandardResolver.Instance, DynamicObjectResolverAllowPrivate.Instance, DynamicContractlessObjectResolverAllowPrivate.Instance }
                    )
                );

            public object Deserialize(byte[] bin)
                => MessagePackSerializer.Typeless.Deserialize(bin, customOptions);

            public Assembly[] GetRequiredAssemblies() => [GetType().Assembly, typeof(MessagePackSerializer).Assembly];

            public byte[] Serialize(object obj)
                => MessagePackSerializer.Typeless.Serialize(obj, customOptions);
        }
    }
}