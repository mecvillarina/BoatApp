using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class BoatRequestContract
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("request_type")]
    public string RequestType { get; set; }

  
    [JsonPropertyName("boat_number")]
    public string BoatNumber { get; set; }

    [JsonPropertyName("boat_name")]
    public string BoatName { get; set; }
    
    [JsonPropertyName("image_url")]
    public string BoatImageUrl { get; set; }

    [JsonPropertyName("owner_id")]
    public string OwnerId { get; set; }
    
    [JsonPropertyName("owner_name")]
    public string OwnerName{ get; set; }
    
    [JsonPropertyName("pickup_point")]
    public string PickupPoint { get; set; }

    [JsonPropertyName("date")]
    public string PickupDate { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("origin")]
    public BoatLocationContract Origin { get; set; }

    [JsonPropertyName("destination")]
    public BoatLocationContract Destination { get; set; }
}
