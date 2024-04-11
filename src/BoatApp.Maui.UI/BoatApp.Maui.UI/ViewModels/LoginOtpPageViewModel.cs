using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Common;

namespace BoatApp.Maui.UI.ViewModels;

public partial class LoginOtpPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    
    public LoginOtpPageViewModel(BasePageServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    [ObservableProperty] private string _phoneNumber = "+1234567890";

    private OwnerContract _user;
    private bool _isAdmin;
    
    [RelayCommand]
    private async Task Login()
    { 
        if (_isAdmin)
        {
            _userService.SaveAdminProfile();
            await NavigationService.NavigateAsync($"../{nameof(AdminMainPage)}");
        }
        else
        {
            _userService.SaveUserProfile(_user);
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
        _user = parameters.GetValue<OwnerContract>("User");

        _isAdmin = _user == null;
    }
}