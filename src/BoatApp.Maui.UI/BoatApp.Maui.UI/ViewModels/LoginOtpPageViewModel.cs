using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Common;

namespace BoatApp.Maui.UI.ViewModels;

public partial class LoginOtpPageViewModel : PageViewModelBase
{
    public LoginOtpPageViewModel(BasePageServices baseServices) : base(baseServices)
    {
    }

    [ObservableProperty] private string _phoneNumber = "+1234567890";

    private bool _isAdmin;
    
    [RelayCommand]
    private async Task Login()
    { 
        if (_isAdmin)
        {
            await NavigationService.NavigateAsync($"../{nameof(AdminMainPage)}");
        }
        else
        {
            await NavigationService.NavigateAsync($"../{nameof(UserMainPage)}");
        }
    }
    
    [RelayCommand]
    private async Task ResendOtp()
    {
        await NavigationService.NavigateAsync($"../{nameof(LoginPage)}");
    }

    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        PhoneNumber = parameters.GetValue<string>("PhoneNumber");
        _isAdmin = parameters.GetValue<bool>("IsAdmin");
    }
}