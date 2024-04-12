using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class BoatLocationContract
{
    [JsonPropertyName("dock")]
    public string Dock { get; set; }

    [JsonPropertyName("zone")]
    public string Zone { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }
}