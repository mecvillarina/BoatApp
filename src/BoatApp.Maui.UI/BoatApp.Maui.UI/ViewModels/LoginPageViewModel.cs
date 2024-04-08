using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class LoginPageViewModel : PageViewModelBase
{
    public LoginPageViewModel(BasePageServices baseServices) : base(baseServices)
    {
    }

    [ObservableProperty] private string _phoneNumber = "+1";

    [RelayCommand]
    private async Task Continue()
    {
        //API Call

        await NavigationService.NavigateAsync($"../{nameof(LoginOtpPage)}");
    }
    
}