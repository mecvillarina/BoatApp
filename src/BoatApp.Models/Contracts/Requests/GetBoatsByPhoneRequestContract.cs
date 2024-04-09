using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetBoatsByPhoneRequestContract : IFilterRequestContract
{
    [JsonPropertyName("owner_phone_number")]
    public string OwnerPhoneNumber { get; set; }
}