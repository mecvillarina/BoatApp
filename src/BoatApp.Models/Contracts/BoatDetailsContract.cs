using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class BoatDetailsContract
{
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }

    [JsonPropertyName("mode")]
    public string Mode { get; set; }

    [JsonPropertyName("speed")]
    public int Speed { get; set; }
}