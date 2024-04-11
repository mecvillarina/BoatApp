using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class AdminMainPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    private readonly IRegionManager _regionManager;
    
    public AdminMainPageViewModel(BaseServices baseServices, IUserService userService, IRegionManager regionManager) : base(baseServices)
    {
        _userService = userService;
        _regionManager = regionManager;
    }

    [ObservableProperty] private List<string> _recentRequests = new List<string>() { "1", "2", "3", "4", "5"};
    [ObservableProperty] private bool _isBoatDropOffRegion = false;

    [RelayCommand]
    private void ManageDropOff()
    {
        IsBoatDropOffRegion = true;
    }
    
    [RelayCommand]
    private async Task Logout()
    {
        _userService.ClearData();
        await NavigationService.NavigateAsync($"../{nameof(SplashScreenPage)}");
    }

}