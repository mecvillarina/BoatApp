using BoatApp.Common.Constants;
using BoatApp.Maui.Domain.Services;
using BoatApp.Maui.UI.Models;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;
using BoatApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class AdminMainPageViewModel : PageViewModelBase
{
    private readonly IUserService _userService;
    private readonly IAdminBoatRequestService _adminBoatRequestService;
    private readonly IPopupService _popupService;
    private readonly IBoatService _boatService;
    
    public AdminMainPageViewModel(BaseServices baseServices, IUserService userService, IAdminBoatRequestService adminBoatRequestService, IPopupService popupService, IBoatService boatService) : base(baseServices)
    {
        _userService = userService;
        _adminBoatRequestService = adminBoatRequestService;
        _popupService = popupService;
        _boatService = boatService;
    }

    #region Home Tab Data

    [ObservableProperty] private int _scheduleDropRequestCount;
    [ObservableProperty] private int _schedulePickupRequestCount;
    [ObservableProperty] private bool _isHomeTabRefreshing;

    [ObservableProperty] private List<BoatRequestItemModel> _recentRequests = new();
    [ObservableProperty] private bool _isBoatDropOffRegionVisible = false;
    [ObservableProperty] private List<string> _boatDropOffZones = new() { "Zone Area 1", "Zone Area 2" };
    [ObservableProperty] private bool _isBoatDropOffRegionRefreshing;
    [ObservableProperty] private bool _isBoatDropOffMarkAsTransitButtonVisible;
    [ObservableProperty] private bool _isBoatDropOffMarkAsCompleteButtonVisible;

    [ObservableProperty] private bool _isBoatListRegionVisible = false;
    [ObservableProperty] private bool _isBoatListRegionRefreshing = false;
    [ObservableProperty] private List<CustomBoatOwnerItemModel> _boatList = new();
    [ObservableProperty] private List<CustomBoatOwnerItemModel> _filteredBoatList = new();
    [ObservableProperty] private string _boatListSearchQuery;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(BoatDropOffListDisplay))]
    private List<BoatRequestItemModel> _boatDropOffRequests = new ();

    [ObservableProperty] private bool _isSendingData;

    public string BoatDropOffListDisplay => $"{BoatDropOffRequests.Count} Drop Off";

    partial void OnBoatListSearchQueryChanged(string? oldValue, string? newValue)
    {
        SearchOnBoatListCommand?.Execute(null);
    }
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
    [ObservableProperty] private bool _isBoatTabRefreshing;
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
    private void RefreshBoatDropOffData()
    {
        FetchBoatDropOffData();
    }
    
    [RelayCommand]
    private void RefreshBoatListData()
    {
        FetchBoatListRegionData();
    }


    [RelayCommand]
    private void AcceptDropOff(BoatRequestItemModel model)
    {
        Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsSendingData = true;
                    await _adminBoatRequestService.ConfirmDropRequestAsync(model.Contract.BoatNumber);
                    await _boatService.UpdateBoatStatusAsync(model.Contract.BoatNumber,
                        BoatRequestStatusConstants.DropConfirmed);
                    await _popupService.ShowAsync(new DropRequestConfirmedPopup());
                    IsHomeTabRefreshing = true;
                }
                catch(Exception ex)
                {
                }
                finally
                {
                    IsSendingData = false;
                }
            });
        });
    }
   
    [RelayCommand]
    private void HomeTabManageDropOff()
    {
        IsBoatDropOffRegionVisible = true;
        IsBoatDropOffRegionRefreshing = true;
    }
    
    [RelayCommand]
    private void HomeTabManageBoatList()
    {
        BoatListSearchQuery = string.Empty;
        IsBoatListRegionVisible = true;
        IsBoatListRegionRefreshing = true;
    }
    
    [RelayCommand]
    private void HomeTabNavigateBack()
    {
        if (IsSendingData) return;
        
        if (IsBoatDropOffRegionVisible)
        {
            IsBoatDropOffRegionVisible = false;
            IsHomeTabRefreshing = true;
        }
        else if (IsBoatListRegionVisible)
        {
            IsBoatListRegionVisible = false;
            IsHomeTabRefreshing = true;
        }
        else
        {
            // IsBoatDropOffRegionVisible = true;
        }
    }

    [RelayCommand]
    private void MarkAsTransit()
    {
        Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsSendingData = true;
                    await _adminBoatRequestService.MarkAsTransitAsync();

                    foreach (var request in BoatDropOffRequests)
                    {
                        await _boatService.UpdateBoatStatusAsync(request.Contract.BoatNumber,
                            BoatRequestStatusConstants.InTransitDrop);
                    }
                    IsBoatDropOffRegionRefreshing = true;
                }
                catch
                {
                }
                finally
                {
                    IsSendingData = false;
                }
            });
        });
    }

    [RelayCommand]
    private void MarkAsComplete()
    {
        Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    IsSendingData = true;
                    await _adminBoatRequestService.MarkAsCompleteAsync();
                    
                    foreach (var request in BoatDropOffRequests)
                    {
                        await _boatService.UpdateBoatStatusAsync(request.Contract.BoatNumber,
                            BoatRequestStatusConstants.DropOffCompleted);
                    }
                    
                    IsBoatDropOffRegionRefreshing = true;
                }
                catch
                {
                }
                finally
                {
                    IsSendingData = false;
                }
            });
        });
    }

    [RelayCommand]
    private async Task RequestDrop(CustomBoatOwnerItemModel model)
    {
        try
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            await _boatService.SubmitDropRequestAsync(new SubmitDropRequestParameter()
            {
                BoatName = model.BoatContract.BoatName,
                BoatNumber = model.BoatContract.BoatNumber,
                BoatImageUrl = model.BoatContract.ImageUrl,
                
                OwnerId = model.BoatContract.OwnerId,
                OwnerName = model.OwnerContract.Name,
                
                PickupPoint = "Shuttle Club Point 1",
                PickupDate = date
            });
            await _boatService.UpdateBoatStatusAsync(model.BoatContract.BoatNumber, BoatRequestStatusConstants.DropRequestSubmitted);
            await _popupService.ShowAsync(new DropRequestSubmittedPopup());
            IsBoatListRegionRefreshing = true;
        }
        catch(Exception ex)
        {
            await PageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
        }
    }
    
    private void FetchHomeTabData()
    {
        Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    var confirmDropOffRequests = await _adminBoatRequestService.GetScheduleDropRequestsAsync();
                    var confirmPickupRequests = await _adminBoatRequestService.GetSchedulePickupRequestsAsync();

                    ScheduleDropRequestCount = confirmDropOffRequests.Count;
                    SchedulePickupRequestCount = confirmPickupRequests.Count;

                    var dropOffSubmittedRequests = await _adminBoatRequestService.GetRecentRequestsAsync();
                    var recentRequests = dropOffSubmittedRequests.Select(x => new BoatRequestItemModel(x)).ToList();
                    RecentRequests = recentRequests.OrderBy(x => (int)(x.RequestStatus)).ToList();
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    IsHomeTabRefreshing = false;
                }
            });
        });
    }
    
    private void FetchBoatDropOffData()
    {
        Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                IsBoatDropOffMarkAsTransitButtonVisible = false;
                IsBoatDropOffMarkAsCompleteButtonVisible = false;
                BoatDropOffRequests = new();
                try
                {
                    var dropConfirmedRequests = await _adminBoatRequestService.GetAllConfirmedDropRequestsAsync();

                    if (dropConfirmedRequests.Any())
                    {
                        BoatDropOffRequests = dropConfirmedRequests.Select(x => new BoatRequestItemModel(x)).ToList();
                        IsBoatDropOffMarkAsTransitButtonVisible = true;
                    }
                    else
                    {
                        var inTransitRequests = await _adminBoatRequestService.GetAllInTransitDropRequestsAsync();

                        if (inTransitRequests.Any())
                        {
                            BoatDropOffRequests = inTransitRequests.Select(x => new BoatRequestItemModel(x)).ToList();
                            IsBoatDropOffMarkAsCompleteButtonVisible = true;
                        }
                        else
                        {
                            var dropCompletedRequests = await _adminBoatRequestService.GetAllDropCompletedRequestsAsync();
                            BoatDropOffRequests = dropCompletedRequests.Select(x => new BoatRequestItemModel(x)).ToList();
                        }
                    }
               
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        IsBoatDropOffRegionRefreshing = false;
                    });
                }
            });
        });
    }
    
    private void FetchBoatListRegionData()
    {
        Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                BoatList = new();
                FilteredBoatList = new List<CustomBoatOwnerItemModel>();
                try
                {
                   var boats = await _boatService.FetchBoatsAsync();
                   BoatList = boats.Select(x => new CustomBoatOwnerItemModel(x.Owner, x.Boat)).ToList();
                   
                   SearchOnBoatListCommand?.Execute(null);
                }
                catch
                {
                    //ignored
                }
                finally
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        IsBoatListRegionRefreshing = false;
                    });
                }
            });
        });
    }

    [RelayCommand]
    private async Task SearchOnBoatList()
    {
        var query = BoatListSearchQuery.Trim();
        FilteredBoatList = BoatList.Where(x =>
        {
            return string.IsNullOrEmpty(query) ||
                   x.BoatName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                   x.OwnerName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                   x.BoatNumber.Contains(query, StringComparison.OrdinalIgnoreCase);
        }).ToList();
    }
    #endregion
    
    #region Boat Tab Methods
    [RelayCommand]
    private void RefreshBoatTabData()
    {
        FetchBoatTabData();
    }

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

    private void FetchBoatTabData()
    {
        Task.Run(async () =>
        {
            try
            {
                
            }
            catch
            {
                // ignored
            }
            finally
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    IsBoatTabRefreshing = false;
                });
            }
           
        });
    }
    #endregion
    
    [RelayCommand]
    private async Task Logout()
    {
        _userService.ClearData();
        await NavigationService.NavigateAsync($"../{nameof(SplashScreenPage)}");
    }

    protected override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);

        IsHomeTabRefreshing = true;
    }
}