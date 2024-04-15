using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class ConfirmDropUpdateSetRequestContract
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
}