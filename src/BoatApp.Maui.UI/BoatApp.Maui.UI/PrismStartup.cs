using BoatApp.Maui.Services.Modules;
using BoatApp.Maui.UI.ViewModels;
using BoatApp.Maui.UI.Views;

namespace BoatApp.Maui.UI;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
            .ConfigureModuleCatalog(ConfigureModuleCatalog)
            .OnInitialized(OnInitialized)
            .CreateWindow(async (containerRegistry, navigationService) =>
            {
                var page = nameof(SplashScreenPage);
                var result = await navigationService.NavigateAsync($"{nameof(NavigationPage)}/{page}");
            });
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterViews();
        containerRegistry.RegisterServices();
    }

    private static void RegisterViews(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<SplashScreenPage, SplashScreenPageViewModel>();
        
        //Auth
        containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        containerRegistry.RegisterForNavigation<LoginOtpPage, LoginOtpPageViewModel>();
        
        //Main Pages
        containerRegistry.RegisterForNavigation<AdminMainPage, AdminMainPageViewModel>();
        containerRegistry.RegisterForNavigation<UserMainPage, UserMainPageViewModel>();
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {

    }

    private static void OnInitialized(IContainerProvider container)
    {

    }

    private static void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog
            .AddModule<PersistenceModule>()
            .AddModule<MauiServicesModule>()
            .AddModule<ServicesModule>()
            .AddModule<WebModule>();
    }
}
