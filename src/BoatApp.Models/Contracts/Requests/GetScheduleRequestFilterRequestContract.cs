using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetScheduleRequestFilterRequestContract
{
    [JsonPropertyName("$and")]
    public List<GetScheduleRequestAndOperatorRequestContract> And { get; set; }
}