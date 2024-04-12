using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public  class BoatContract
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("boat_number")]
    public string BoatNumber { get; set; }

    [JsonPropertyName("boat_name")]
    public string BoatName { get; set; }

    [JsonPropertyName("owner_id")]
    public string OwnerId { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("request_status")]
    public string RequestStatus { get; set; }

    [JsonPropertyName("boat_details")]
    public BoatDetailsContract BoatDetailsContract { get; set; }

    [JsonPropertyName("parking_location")]
    public BoatLocationContract BoatLocationContract { get; set; }

    [JsonPropertyName("owner_phone_number")]
    public string OwnerPhoneNumber { get; set; }
}