using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Models;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class AdminMainPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    private readonly IAdminBoatRequestService _adminBoatRequestService;
    
    public AdminMainPageViewModel(BaseServices baseServices, IUserService userService, IAdminBoatRequestService adminBoatRequestService) : base(baseServices)
    {
        _userService = userService;
        _adminBoatRequestService = adminBoatRequestService;
    }

    #region Home Tab Data

    [ObservableProperty] private int _scheduleDropRequestCount;
    [ObservableProperty] private int _schedulePickupRequestCount;
    [ObservableProperty] private bool _isHomeTabRefreshing;
    
    [ObservableProperty] private List<string> _recentRequests = new List<string>() { "1", "2", "3", "4", "5"};
    [ObservableProperty] private bool _isBoatDropOffRegionVisible = false;
    [ObservableProperty] private List<string> _boatDropOffZones = new() { "Zone Area 1", "Zone Area 2" };
    [ObservableProperty] private List<string> _boatDropOffRequests = new() { "Zone Area 1", "Zone Area 2" };

    #endregion
    
    #region Boat Tab Data
    [ObservableProperty] private List<BoatOwnerItemModel> _boatOwnerList = new List<BoatOwnerItemModel>()
    {
        new BoatOwnerItemModel() { Name = "John Doe", Email = "johndoe@gmail.com", PhoneNumber = "+12-859-7080", ProfilePictureUrl = "https://www.svgrepo.com/download/382103/male-avatar-boy-face-man-user-2.svg", Boats = new() { "", "", "" } },
        new BoatOwnerItemModel() { Name = "Olivia Jones", Email = "olivia@gmail.com", PhoneNumber = "+12-859-7080", ProfilePictureUrl = "https://www.svgrepo.com/download/382103/male-avatar-boy-face-man-user-2.svg", Boats = new() { "", "", "", "", "" } },
        new BoatOwnerItemModel() { Name = "Nelson Smith", Email = "nelson@gmail.com", PhoneNumber = "+12-859-7080", ProfilePictureUrl = "https://www.svgrepo.com/download/382103/male-avatar-boy-face-man-user-2.svg", Boats = new() { "", "", "", "", "" } },
        new BoatOwnerItemModel() { Name = "Stefan William", Email = "stefan@gmail.com", PhoneNumber = "+12-859-7080", ProfilePictureUrl = "https://www.svgrepo.com/download/382103/male-avatar-boy-face-man-user-2.svg", Boats = new() { "", "", "", "", "" } },
        new BoatOwnerItemModel() { Name = "Andrew Medal", Email = "andrew@gmail.com", PhoneNumber = "+12-859-7080", ProfilePictureUrl = "https://www.svgrepo.com/download/382103/male-avatar-boy-face-man-user-2.svg", Boats = new() { "", "", "", "", "" } },
    };

    [ObservableProperty] private BoatOwnerItemModel _currentBoatOwner;
    [ObservableProperty] private bool _isBoatOwnerDetailsRegionVisible = false;
    #endregion

    #region Home Tab Methods

    [RelayCommand]
    private void RefreshHomeTabData()
    {
        FetchHomeTabData();
    }
    [RelayCommand]
    private void HomeTabManageDropOff()
    {
        IsBoatDropOffRegionVisible = true;
    }
    
    [RelayCommand]
    private void HomeTabNavigateBack()
    {
        if (IsBoatDropOffRegionVisible)
        {
            IsBoatDropOffRegionVisible = false;
        }
        else
        {
            // IsBoatDropOffRegionVisible = true;
        }
    }
    
    private void FetchHomeTabData()
    {
        Task.Run(async () =>
        {
            try
            {
                var dropOffCount = await _adminBoatRequestService.GetScheduleDropRequestsCountAsync();
                var pickupCount = await _adminBoatRequestService.GetSchedulePickupRequestsCountAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ScheduleDropRequestCount = dropOffCount;
                    SchedulePickupRequestCount = pickupCount;
                });
            }
            catch
            {
                // ignored
            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IsHomeTabRefreshing = false;
                });
            }
           
        });
    }
    #endregion
    
    
    [RelayCommand]
    private void BoatsTabViewBoatDetails(BoatOwnerItemModel model)
    {
        IsBoatOwnerDetailsRegionVisible = true;
        CurrentBoatOwner = model;
    }
    
    [RelayCommand]
    private void BoatsTabNavigateBack()
    {
        if (IsBoatOwnerDetailsRegionVisible)
        {
            IsBoatOwnerDetailsRegionVisible = false;
        }
        else
        {
            // IsBoatOwnerDetailsRegionVisible = true;
        }
    }
    
    [RelayCommand]
    private async Task Logout()
    {
        _userService.ClearData();
        await NavigationService.NavigateAsync($"../{nameof(SplashScreenPage)}");
    }

    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);
        
        FetchHomeTabData();
    }
}