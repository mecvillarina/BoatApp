using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BoatApp.Maui.UI.ViewModels;

public partial class UserMainPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    public UserMainPageViewModel(BasePageServices baseServices, IUserService userService) : base(baseServices)
    {
        _userService = userService;
    }

    private OwnerContract _user;
    [ObservableProperty] private string _welcomeNameDisplay;
    [ObservableProperty] private string _memberSinceDisplay;
    [ObservableProperty] private string _profilePictureUrl;
    
    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        _user = _userService.GetUserProfile();

        WelcomeNameDisplay = $"Welcome {_user.Name}";
        MemberSinceDisplay = $"Member Since {_user.MemberSince}";
        ProfilePictureUrl = _user.ProfilePic.AbsoluteUri;
    }
}