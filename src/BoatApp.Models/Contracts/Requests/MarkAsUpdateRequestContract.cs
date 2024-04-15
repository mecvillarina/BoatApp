using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class MarkAsUpdateRequestContract
{
    [JsonPropertyName("$set")]
    public MarkAsUpdateSetRequestContract Set { get; set; }
}