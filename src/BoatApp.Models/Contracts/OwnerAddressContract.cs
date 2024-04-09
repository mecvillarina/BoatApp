using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class OwnerAddressContract
{
    [JsonPropertyName("address_lines")]
    public List<string> AddressLines { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("zip")]
    public string Zip { get; set; }
}