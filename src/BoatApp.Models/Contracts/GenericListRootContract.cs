using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class GenericListRootContract<T>
{
    [JsonPropertyName("documents")]
    public List<T> Documents { get; set; }
}