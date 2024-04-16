using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class LoginPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    
    public LoginPageViewModel(BaseServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ContinueCommand))]
    private string _phoneNumber = "+1";

    [ObservableProperty] private bool _isLoggingIn;
    
    public bool CanExecuteContinue() => PhoneNumber.Length == 11 && PhoneNumber.StartsWith($"+1") && PhoneNumber.Substring(2, 9).All(x => char.IsNumber((x)));
    
    [RelayCommand(CanExecute = nameof(CanExecuteContinue))]
    private async Task Continue()
    {
        try
        {
            IsLoggingIn = true;
            var phoneNumberOnly = PhoneNumber.Replace("+1", "");
            var isAdmin = phoneNumberOnly.All(x => x == '0') || phoneNumberOnly.All((x => x == '1'));

            if (!isAdmin)
            {
                var user = await _userService.FetchUserByPhoneNumberAsync(PhoneNumber);

                var parameters = new NavigationParameters()
                {
                    { "User", user },
                };

                var result = await NavigationService.NavigateAsync($"../{nameof(LoginOtpPage)}", parameters);
            }
            else
            {
                _userService.SaveAdminProfile();
                await NavigationService.NavigateAsync($"../{nameof(AdminMainPage)}");
            }

        }
        catch (Exception ex)
        {
            await PageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
        }
        finally
        {
            IsLoggingIn = false;
        }
    }
    
}