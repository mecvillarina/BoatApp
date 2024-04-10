using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class SubmitDropRequestLocationRequestContract
{
    [JsonPropertyName("dock")]
    public string Dock { get; set; }

    [JsonPropertyName("zone")]
    public string Zone { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}