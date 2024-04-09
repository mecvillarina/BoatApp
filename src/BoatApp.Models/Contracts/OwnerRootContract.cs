using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class OwnerRootContract
{
    [JsonPropertyName("documents")]
    public List<OwnerContract> Documents { get; set; }
}