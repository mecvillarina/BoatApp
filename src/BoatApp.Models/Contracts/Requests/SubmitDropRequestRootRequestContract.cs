using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class SubmitDropRequestRootRequestContract
{
    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; }

    [JsonPropertyName("database")]
    public string Database { get; set; }

    [JsonPropertyName("collection")]
    public string Collection { get; set; }

    [JsonPropertyName("document")]
    public SubmitDropRequestDocumentRequestContract Document { get; set; }
}