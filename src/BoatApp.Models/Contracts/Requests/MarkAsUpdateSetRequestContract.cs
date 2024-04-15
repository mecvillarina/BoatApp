using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class MarkAsUpdateSetRequestContract
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
}