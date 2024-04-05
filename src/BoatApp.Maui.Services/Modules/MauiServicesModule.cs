namespace BoatApp.Maui.Services.Modules;

public class MauiServicesModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance(Browser.Default);
        containerRegistry.RegisterInstance(SecureStorage.Default);
        containerRegistry.RegisterInstance(Preferences.Default);
        containerRegistry.RegisterInstance(Connectivity.Current);
        containerRegistry.RegisterInstance(Clipboard.Default);
        containerRegistry.RegisterInstance(AppInfo.Current);
    }
}
