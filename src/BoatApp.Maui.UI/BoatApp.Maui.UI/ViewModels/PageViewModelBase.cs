using BoatApp.Maui.UI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BoatApp.Maui.UI.ViewModels;

public partial class PageViewModelBase : ObservableObject, IPageLifecycleAware, IInitialize, INavigationAware, IDestructible
{
    private readonly BasePageServices _baseServices;

    protected PageViewModelBase(BasePageServices baseServices)
    {
        _baseServices = baseServices;
    }

    public INavigationService NavigationService => _baseServices.NavigationService;

    protected IPageDialogService PageDialogService => _baseServices.PageDialogService;

    protected IEventAggregator EventAggregator => _baseServices.EventAggregator;

    [ObservableProperty]
    private bool _isControlEnabled = true;

    protected virtual void OnAppearing()
    {
    }

    protected virtual void OnDisappearing()
    {
    }

    protected virtual void Initialize(INavigationParameters parameters)
    {
    }

    protected virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    protected virtual void OnNavigatedTo(INavigationParameters parameters)
    {
    }

    protected virtual void Destroy()
    {
    }

    void IPageLifecycleAware.OnAppearing()
    {
        OnAppearing();
    }

    void IPageLifecycleAware.OnDisappearing()
    {
        OnDisappearing();
    }

    void IInitialize.Initialize(INavigationParameters parameters)
    {
        Initialize(parameters);
    }

    void INavigatedAware.OnNavigatedFrom(INavigationParameters parameters)
    {
        OnNavigatedFrom(parameters);
    }

    void INavigatedAware.OnNavigatedTo(INavigationParameters parameters)
    {
        OnNavigatedTo(parameters);
    }

    void IDestructible.Destroy()
    {
        Destroy();
    }

    protected bool HasInternetConnection => _baseServices.Connectivity.NetworkAccess == NetworkAccess.Internet;

    [RelayCommand]
    private void HideKeyboard()
    {
        IsControlEnabled = false;
        IsControlEnabled = true;
    }
}
