using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public  class UpdateBoatStatusUpdateRequestContract
{
    [JsonPropertyName("$set")]
    public UpdateBoatStatusUpdateSetRequestContract UpdateBoatStatusUpdateSetRequestContract { get; set; }
}