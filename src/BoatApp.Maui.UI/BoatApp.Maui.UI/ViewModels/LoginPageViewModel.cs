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
    
    public LoginPageViewModel(BasePageServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ContinueCommand))]
    private string _phoneNumber = "+1";

    public bool CanExecuteContinue() => PhoneNumber.Length == 12 && PhoneNumber.StartsWith($"+") && PhoneNumber.Substring(2, 10).All(x => char.IsNumber((x)));
    
    [RelayCommand(CanExecute = nameof(CanExecuteContinue))]
    private async Task Continue()
    {
        try
        {
            //API Call
            var phoneNumberOnly = PhoneNumber.Replace("+", "");
            var isAdmin =  phoneNumberOnly.All(x => x == '0') || phoneNumberOnly.All((x => x == '1'));

            OwnerContract user = null;
            
            if(!isAdmin)
            {
                user = await _userService.FetchUserByPhoneNumberAsync(PhoneNumber);
            }
            
            var parameters = new NavigationParameters()
            {
                { "PhoneNumber", PhoneNumber },
                { "User", user },
            };
        
            var result = await NavigationService.NavigateAsync($"../{nameof(LoginOtpPage)}", parameters);
        }
        catch(Exception ex)
        {
            await PageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
        }
    }
    
}