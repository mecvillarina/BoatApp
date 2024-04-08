using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class LoginOtpPageViewModel : PageViewModelBase
{
    public LoginOtpPageViewModel(BasePageServices baseServices) : base(baseServices)
    {
    }

    [RelayCommand]
    private async Task Login()
    {
        await NavigationService.NavigateAsync($"../{nameof(UserMainPage)}");
    }
    
    [RelayCommand]
    private async Task ResendOtp()
    {
        await NavigationService.NavigateAsync($"../{nameof(LoginPage)}");
    }
}