using BoatApp.Maui.Services.PubSubEvents;
using BoatApp.Maui.UI.Services;
using BoatApp.Maui.UI.Views;

namespace BoatApp.Maui.UI.ViewModels;

public partial class BoatOwnerDetailsViewModel : RegionViewModelBase
{
    private readonly SubscriptionToken _viewOnNavigatedSubscriptionToken;

    public BoatOwnerDetailsViewModel(BaseServices baseServices) : base(baseServices)
    {
        _viewOnNavigatedSubscriptionToken = EventAggregator.GetEvent<ViewOnNavigatedToEvent>().Subscribe(async viewName =>
        {
            if (viewName == nameof(BoatOwnerDetailsView))
            {
                await FetchDataAsync();
            }
        });
    }

    private async Task FetchDataAsync()
    {
        
    }
    
    protected override void Destroy()
    {
        base.Destroy();
        
        EventAggregator.GetEvent<ViewOnNavigatedToEvent>().Unsubscribe(_viewOnNavigatedSubscriptionToken);

    }
}