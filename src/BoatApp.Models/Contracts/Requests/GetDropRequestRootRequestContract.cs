using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GetDropRequestRootRequestContract
{
    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; }

    [JsonPropertyName("database")]
    public string Database { get; set; }

    [JsonPropertyName("collection")]
    public string Collection { get; set; }
    
    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GetDropRequestFilterRequestContract Filter { get; set; }
}