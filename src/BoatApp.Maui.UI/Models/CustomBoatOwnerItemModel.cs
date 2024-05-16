using System.Collections.ObjectModel;
using BoatApp.Common.Enums;
using BoatApp.Common.Extensions;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BoatApp.Maui.UI.Models;

public partial class CustomBoatOwnerItemModel : ObservableObject
{
    public BoatContract BoatContract { get; private set; }
    public OwnerContract OwnerContract { get; private set; }

    [ObservableProperty] private string _ownerName;
    [ObservableProperty] private string _ownerPhoneNumber;
    [ObservableProperty] private string _ownerProfilePic;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(BoatDisplay))]
    private string _boatName;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(BoatDisplay))]
    private string _boatNumber;
    
    [ObservableProperty] private string _boatImageUrl;
    [ObservableProperty] private string _parkingLocationAddress;
    [ObservableProperty] private string _parkingLocationDock;
    [ObservableProperty] private string _parkingLocationZone;

    public string BoatDisplay => $"{BoatName} - {BoatNumber}";
    [ObservableProperty] 
    // [NotifyPropertyChangedFor((nameof(CanRequestDrop)))]
    private BoatRequestStatus _requestStatus;
    //
    // public bool CanRequestDrop => RequestStatus == BoatRequestStatus.RequestDrop;
    //

    public CustomBoatOwnerItemModel(OwnerContract owner, BoatContract boat)
    {
        OwnerContract = owner;
        BoatContract = boat;

        OwnerName = owner.Name;
        OwnerPhoneNumber = boat.OwnerPhoneNumber;
        OwnerProfilePic = owner.ProfilePic;
        
        BoatName = boat.BoatName ?? "Not Available";
        BoatNumber = boat.BoatNumber;
        BoatImageUrl = boat.ImageUrl;
        ParkingLocationAddress = boat.ParkingLocation.Address;
        ParkingLocationDock = boat.ParkingLocation.Dock;
        ParkingLocationZone = boat.ParkingLocation.Zone;
        
        RequestStatus = EnumExtensions.GetBoatRequestStatus(boat.RequestStatus);
    }
}