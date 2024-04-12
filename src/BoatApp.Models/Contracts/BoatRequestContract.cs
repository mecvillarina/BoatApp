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

    [JsonPropertyName("owner_id")]
    public string OwnerId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("origin")]
    public BoatLocationContract Origin { get; set; }

    [JsonPropertyName("destination")]
    public BoatLocationContract Destination { get; set; }
}
