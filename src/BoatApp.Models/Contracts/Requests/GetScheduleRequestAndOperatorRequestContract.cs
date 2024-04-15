using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetScheduleRequestAndOperatorRequestContract
{
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("request_type")]
        public string RequestType { get; set; }
}