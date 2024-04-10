using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public  class UpdateBoatStatusUpdateSetRequestContract
{
    [JsonPropertyName("request_status")]
    public string RequestStatus { get; set; }
}