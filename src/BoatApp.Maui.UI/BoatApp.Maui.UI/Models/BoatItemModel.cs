using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BoatApp.Maui.UI.Models;

public partial class BoatItemModel : ObservableObject
{
    public BoatContract Contract { get; set; }

    [ObservableProperty] private string _boatName;
    [ObservableProperty] private string _parkingLocationAddress;
    [ObservableProperty] private string _parkingLocationDock;
    [ObservableProperty] private string _parkingLocationZone;
    [ObservableProperty] private string _boatImageUrl;
    [ObservableProperty] private string _requestStatus;
    
    public BoatItemModel(BoatContract contract)
    {
        Contract = contract;
        BoatName = contract.BoatName;
        BoatImageUrl = contract.ImageUrl;
        RequestStatus = contract.RequestStatus;
        ParkingLocationAddress = contract.BoatParkingLocation.Address;
        ParkingLocationDock = contract.BoatParkingLocation.Dock;
        ParkingLocationZone = contract.BoatParkingLocation.Zone;

    }
}