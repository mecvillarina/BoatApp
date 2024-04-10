using BoatApp.Common.Enums;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;

namespace BoatApp.Maui.UI.ViewModels;

public class SplashScreenPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    public SplashScreenPageViewModel(BasePageServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    protected override async void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        await Task.Delay(500);

        var userType = _userService.GetCurrentUserType();

        switch (userType)
        {
            case null:
                await NavigationService.NavigateAsync($"../{nameof(LoginPage)}");
                break;
            case UserType.Admin:
                await NavigationService.NavigateAsync($"../{nameof(AdminMainPage)}");
                break;
            case UserType.User:
                var result = await NavigationService.NavigateAsync($"../{nameof(UserMainPage)}");
                break;
        }
    }
}