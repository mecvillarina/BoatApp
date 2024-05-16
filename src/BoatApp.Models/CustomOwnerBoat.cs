using BoatApp.Models.Contracts;

namespace BoatApp.Models;

public class CustomOwnerBoat
{
    public BoatContract Boat { get; set; }
    public OwnerContract Owner { get; set; }
}