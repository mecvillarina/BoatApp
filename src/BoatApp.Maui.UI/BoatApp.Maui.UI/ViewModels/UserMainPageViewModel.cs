using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Models;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class UserMainPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    private readonly IOwnerBoatService _ownerBoatService;
    private readonly IPopupService _popupService;
    public UserMainPageViewModel(BasePageServices baseServices, IUserService userService, IOwnerBoatService ownerBoatService, IPopupService popupService) : base(baseServices)
    {
        _userService = userService;
        _ownerBoatService = ownerBoatService;
        _popupService = popupService;
    }

    private OwnerContract _user;
    [ObservableProperty] private string _welcomeNameDisplay;
    [ObservableProperty] private string _memberSinceDisplay;
    [ObservableProperty] private string _profilePictureUrl;

    [ObservableProperty] private List<BoatItemModel> _boats = [];

    [RelayCommand]
    private async Task RequestDrop()
    {
        try
        {
             await _popupService.ShowAsync(new DropRequestSubmittedPopup());
        }
        catch(Exception ex)
        {
            
        }
    }
    
    private void SetUserDetails()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            _user = _userService.GetUserProfile();

            WelcomeNameDisplay = $"Welcome {_user.Name}";
            MemberSinceDisplay = $"Member Since {_user.MemberSince}";
            ProfilePictureUrl = _user.ProfilePic;
        });
    }
    
    private void FetchUserDetails()
    {
        Task.Run(async () =>
        {
            var phoneNumber = _userService.GetUserPhoneNumber();
            await _userService.FetchUserByPhoneNumberAsync(phoneNumber);
            SetUserDetails();
        });
    }
    
    private void FetchBoats()
    {
        Task.Run(async () =>
        {
            var phoneNumber = _userService.GetUserPhoneNumber();
            var boats = await _ownerBoatService.FetchBoatsByPhoneNumberAsync(phoneNumber);
            
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Boats = boats.Select(x => new BoatItemModel(x)).ToList();
            });
        });
    }

    protected override void Initialize(INavigationParameters parameters)
    {
        base.Initialize(parameters);
        SetUserDetails();
    }

    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);
        FetchUserDetails();
        FetchBoats();
    }
}