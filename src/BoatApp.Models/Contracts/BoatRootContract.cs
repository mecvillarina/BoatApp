using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class BoatRootContract
{
    [JsonPropertyName("documents")]
    public List<BoatContract> Documents { get; set; }
}