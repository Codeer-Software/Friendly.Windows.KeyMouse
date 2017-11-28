namespace Codeer.Friendly.Windows.KeyMouse.Inside
{
    static class TargetAppInitializer
    {
        internal static WindowsAppFriend Init(WindowsAppFriend app)
        {
            var key = typeof(TargetAppInitializer).Module.Name + "[Initialize]";
            if (!app.TryGetAppControlInfo(key, out var dummy))
            {
                app.LoadAssembly(typeof(TargetAppInitializer).Assembly);
                app.AddAppControlInfo(key, null);
            }
            return app;
        }
    }
}
