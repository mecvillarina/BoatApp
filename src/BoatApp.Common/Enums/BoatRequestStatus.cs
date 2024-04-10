using System.ComponentModel;

namespace BoatApp.Common.Enums;

public enum BoatRequestStatus
{
    RequestDrop,
    [Description("Drop Request Submitted")]
    DropRequestSubmitted,
    [Description("Drop Confirmed")]
    DropConfirmed,
    [Description("In Transit (Drop) ")]
    InTransitDrop,
    [Description("Drop-Off Completed")]
    DropOffCompleted,
    [Description("Pickup Request Submitted")]
    PickupRequestSubmitted,
    [Description("Pickup Confirmed")]
    PickupConfirmed,
    [Description("In Transit (Pickup)")]
    InTransitPickup,
    [Description("Pickup Completed")]
    PickupCompleted
}