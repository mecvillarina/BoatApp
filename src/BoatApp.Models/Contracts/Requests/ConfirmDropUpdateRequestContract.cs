using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class ConfirmDropUpdateRequestContract
{
    [JsonPropertyName("$set")]
    public ConfirmDropUpdateSetRequestContract Set { get; set; }
}