using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class LoginPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    
    public LoginPageViewModel(BasePageServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ContinueCommand))]
    private string _phoneNumber = "+1";

    public bool CanExecuteContinue() => PhoneNumber.Length == 11 && PhoneNumber.StartsWith($"+") && PhoneNumber.Substring(1, PhoneNumber.Length - 1).All(x => char.IsNumber((x)));
    
    [RelayCommand(CanExecute = nameof(CanExecuteContinue))]
    private async Task Continue()
    {
        try
        {
            //API Call
            var phoneNumberOnly = PhoneNumber.Replace("+", "");
            var isAdmin =  phoneNumberOnly.All(x => x == '0') || phoneNumberOnly.All((x => x == '1'));

            if (isAdmin)
            {
                await _userService.FetchAdminAsync();
            }
            else
            {
                await _userService.FetchUserByPhoneNumberAsync(PhoneNumber);
            }
            
            var parameters = new NavigationParameters()
            {
                { "PhoneNumber", PhoneNumber },
                { "IsAdmin", isAdmin }
            };
        
            var result = await NavigationService.NavigateAsync($"../{nameof(LoginOtpPage)}", parameters);
        }
        catch(Exception ex)
        {
            await PageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
        }
    }
    
}