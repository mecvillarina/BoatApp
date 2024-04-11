namespace BoatApp.Maui.UI.Services;

public class BaseServices
{
    public BaseServices(INavigationService navigationService,
        IPageDialogService pageDialogService,
        IEventAggregator eventAggregator,
        IConnectivity connectivity,
        IRegionManager regionManager)
    {
        NavigationService = navigationService;
        PageDialogService = pageDialogService;
        EventAggregator = eventAggregator;
        Connectivity = connectivity;
        RegionManager = regionManager;
    }

    public INavigationService NavigationService { get; }

    public IPageDialogService PageDialogService { get; }

    public IEventAggregator EventAggregator { get; }

    public IConnectivity Connectivity { get; }

    public IRegionManager RegionManager { get; set; }
}
