using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetDropRequestFilterRequestContract
{
    [JsonPropertyName("$and")]
    public List<GetDropRequestAndOperatorRequestContract> And { get; set; }
}