namespace BoatApp.Maui.Services.Modules;

public class PersistenceModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // containerRegistry.RegisterSingleton<IAppDatabase, AppDatabase>();
    }
}
