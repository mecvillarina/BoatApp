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
        Contract = contract;
        BoatName = contract.BoatName;
        BoatOwner = $"Owner : {contract.OwnerName}";
        BoatImageUrl = contract.BoatImageUrl;
        
        ParkingLocationDock = contract.Origin.Dock;
        ParkingLocationZone = contract.Origin.Zone;
        
        PickupPoint = $"Pickup Point : {contract.PickupPoint} ";
        PickupDate = $"Date : {DateTime.Parse(contract.PickupDate): dddd, MMMM dd, yyyy}";
        PickupTime = "Time : 12.00 PM ";

        RequestStatus = EnumExtensions.GetBoatRequestStatus(contract.Status);
    }
}