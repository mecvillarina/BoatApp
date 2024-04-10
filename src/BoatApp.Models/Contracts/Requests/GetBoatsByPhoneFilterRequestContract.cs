using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetBoatsByPhoneFilterRequestContract 
{
    [JsonPropertyName("owner_phone_number")]
    public string OwnerPhoneNumber { get; set; }
}