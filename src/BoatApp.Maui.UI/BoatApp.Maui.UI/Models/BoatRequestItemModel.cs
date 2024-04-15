using BoatApp.Common.Enums;
using BoatApp.Common.Extensions;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using DryIoc;
using Prism.Common;

namespace BoatApp.Maui.UI.Models;

public partial class BoatRequestItemModel : ObservableObject
{
    public BoatRequestContract Contract { get; set; }
    
    [ObservableProperty] private string _boatName;
    [ObservableProperty] private string _boatOwner;
    [ObservableProperty] private string _boatImageUrl;
    [ObservableProperty] private string _parkingLocationDock;
    [ObservableProperty] private string _parkingLocationZone;
    
    [ObservableProperty] private string _pickupPoint;
    [ObservableProperty] private string _pickupDate;
    [ObservableProperty] private string _pickupTime;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor((nameof(CanRequestDrop)))]
    private BoatRequestStatus _requestStatus;
    public bool CanRequestDrop => RequestStatus == BoatRequestStatus.RequestDrop;

    public BoatRequestItemModel(BoatRequestContract contract)
    {
        BoatName = "The Winder Ranger";
        BoatOwner = "Owner : John Nelson ";
        BoatImageUrl = "https://boatshuttle.blob.core.windows.net/images/Crusing.jpg?sp=r&st=2024-03-27T16:36:11Z&se=2024-10-01T00:36:11Z&spr=https&sv=2022-11-02&sr=b&sig=5Z0LI1pvljKOud3wk7OO7KZFexykTDE754siCb%2F2i90%3D";

        ParkingLocationDock = contract.Origin.Dock;
        ParkingLocationZone = contract.Origin.Zone;
        
        PickupPoint = "Pickup Point : Shuttle Club point 1 ";
        PickupDate = "Date : Saturday, July 10, 2024";
        PickupTime = "Time : 12.00 PM ";

        RequestStatus = EnumExtensions.GetBoatRequestStatus(contract.Status);
    }
}