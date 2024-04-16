using BoatApp.Common.Constants;
using BoatApp.Common.Enums;
using BoatApp.Common.Extensions;
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
    private readonly IBoatService _boatService;
    private readonly IPopupService _popupService;
    public UserMainPageViewModel(BaseServices baseServices, IUserService userService, IBoatService boatService, IPopupService popupService) : base(baseServices)
    {
        _userService = userService;
        _boatService = boatService;
        _popupService = popupService;
    }

    private OwnerContract _user;
    [ObservableProperty] private string _welcomeNameDisplay;
    [ObservableProperty] private string _memberSinceDisplay;
    [ObservableProperty] private string _profilePictureUrl;
    [ObservableProperty] private bool _isMyBoatsRefreshing;
    [ObservableProperty] private List<BoatItemModel> _boats = [];

    [RelayCommand]
    private void RefreshMyBoatsData()
    {
        FetchBoats();
    }
    
    [RelayCommand]
    private async Task RequestDrop(BoatItemModel model)
    {
        try
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            await _boatService.SubmitDropRequestAsync(model.Contract.BoatNumber, model.Contract.OwnerId, model.Contract.BoatName, model.Contract.ImageUrl, "Shuttle Club Point 1", date);
            await _boatService.UpdateBoatStatusAsync(model.Contract.BoatNumber, BoatRequestStatusConstants.DropRequestSubmitted);
            await _popupService.ShowAsync(new DropRequestSubmittedPopup());
            IsMyBoatsRefreshing = true;
        }
        catch(Exception ex)
        {
            await PageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
        }
    }

    [RelayCommand]
    private async Task Logout()
    {
        _userService.ClearData();
        await NavigationService.NavigateAsync($"../{nameof(SplashScreenPage)}");
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
            try
            {
                var phoneNumber = _userService.GetUserPhoneNumber();
                var boats = await _boatService.FetchBoatsByPhoneNumberAsync(phoneNumber);
            
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    Boats = boats.Select(x => new BoatItemModel(x)).ToList();
                });
            }
            catch
            {
                // ignored
            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    IsMyBoatsRefreshing = false;
                });
            }
            
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
        IsMyBoatsRefreshing = true;
    }
}