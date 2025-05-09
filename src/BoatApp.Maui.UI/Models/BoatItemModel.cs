﻿using BoatApp.Common.Enums;
using BoatApp.Common.Extensions;
using BoatApp.Models.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BoatApp.Maui.UI.Models;

public partial class BoatItemModel : ObservableObject
{
    public BoatContract Contract { get; private set; }

    [ObservableProperty] private string _boatName;
    [ObservableProperty] private string _parkingLocationAddress;
    [ObservableProperty] private string _parkingLocationDock;
    [ObservableProperty] private string _parkingLocationZone;
    [ObservableProperty] private string _boatImageUrl;
    
    [ObservableProperty] 
    [NotifyPropertyChangedFor((nameof(CanRequestDrop)))]
    private BoatRequestStatus _requestStatus;

    public bool CanRequestDrop => RequestStatus == BoatRequestStatus.RequestDrop;
    
    public BoatItemModel(BoatContract contract)
    {
        Contract = contract;
        BoatName = contract.BoatName ?? "Not Available";
        BoatImageUrl = contract.ImageUrl;
        RequestStatus = EnumExtensions.GetBoatRequestStatus(contract.RequestStatus);
        ParkingLocationAddress = contract.ParkingLocation.Address;
        ParkingLocationDock = contract.ParkingLocation.Dock;
        ParkingLocationZone = contract.ParkingLocation.Zone;

    }
}