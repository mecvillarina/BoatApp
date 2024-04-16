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
    
    public LoginOtpPageViewModel(BaseServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    [ObservableProperty] private string _phoneNumber;
    [ObservableProperty] private bool _isLoggingIn;

    private OwnerContract _user;
    
    [RelayCommand]
    private async Task Login()
    { 
        IsLoggingIn = true;

        _userService.SaveUserProfile(_user);
        await NavigationService.NavigateAsync($"../{nameof(UserMainPage)}");
        
        IsLoggingIn = false;
    }
    
    [RelayCommand]
    private async Task ResendOtp()
    {
        await NavigationService.NavigateAsync($"../{nameof(LoginPage)}");
    }

    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        _user = parameters.GetValue<OwnerContract>("User");
        PhoneNumber = _user.Contact;
    }
}