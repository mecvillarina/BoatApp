namespace BoatApp.Models;

public class SubmitDropRequestParameter
{   
    public string OwnerId { get; set; }
    
    public string OwnerName{ get; set; }

    public string BoatNumber { get; set; }

    public string BoatName { get; set; }
    
    public string BoatImageUrl { get; set; }

    public string PickupPoint { get; set; }

    public string PickupDate { get; set; }
}