using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public  class UpdateBoatStatusFilterRequestContract
{
    [JsonPropertyName("boat_number")]
    public string BoatNumber { get; set; }
}