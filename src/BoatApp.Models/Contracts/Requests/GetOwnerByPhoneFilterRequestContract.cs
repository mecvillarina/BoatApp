using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetOwnerByPhoneFilterRequestContract 
{
    [JsonPropertyName("contact")]
    public string Contact { get; set; }
}