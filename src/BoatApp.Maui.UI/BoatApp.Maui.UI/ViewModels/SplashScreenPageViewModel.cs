using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;

namespace BoatApp.Maui.UI.ViewModels;

public class SplashScreenPageViewModel : PageViewModelBase
{
    public SplashScreenPageViewModel(BasePageServices baseServices) : base(baseServices)
    {
    }

    protected override async void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        await Task.Delay(5000);

        await NavigationService.NavigateAsync($"../{nameof(LoginPage)}");
    }
}