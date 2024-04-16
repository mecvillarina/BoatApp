using BoatApp.Maui.UI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Common;

namespace BoatApp.Maui.UI.ViewModels;

public partial class RegionViewModelBase : ObservableObject, IRegionAware, IDestructible
{
    private readonly BaseServices _baseServices;

    protected IRegionNavigationJournal? Journal;

    protected RegionViewModelBase(BaseServices baseServices)
    {
        _baseServices = baseServices;
    }

    public IRegionManager RegionManager => _baseServices.RegionManager;

    protected IPageDialogService PageDialogService => _baseServices.PageDialogService;

    protected IEventAggregator EventAggregator => _baseServices.EventAggregator;

    public virtual void OnNavigatedTo(NavigationContext navigationContext) =>
        Journal = navigationContext.NavigationService.Journal;

    public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }


    protected virtual void Destroy()
    {
    }

    void IDestructible.Destroy()
    {
        Destroy();
    }

    [RelayCommand]
    private void NavigateBack()
    {
        if (Journal is { CanGoBack: true })
        {
            Journal?.GoBack();
        }
    }
}