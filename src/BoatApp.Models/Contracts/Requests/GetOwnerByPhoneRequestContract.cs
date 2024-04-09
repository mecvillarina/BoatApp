using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetOwnerByPhoneRequestContract : IFilterRequestContract
{
    [JsonPropertyName("contact")]
    public string Contact { get; set; }
}