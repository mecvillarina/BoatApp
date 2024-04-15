using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class MarkAsFilterRequestContract
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
}