using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts.Requests;

public class GenericRequestContract
{
    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; }

    [JsonPropertyName("database")]
    public string Database { get; set; }

    [JsonPropertyName("collection")]
    public string Collection { get; set; }

    [JsonPropertyName("filter")]
    public BlankRequestContract Filter { get; set; }
}

public class GenericRequestContract<T> where T : IFilterRequestContract
{
    [JsonPropertyName("dataSource")]
    public string DataSource { get; set; }

    [JsonPropertyName("database")]
    public string Database { get; set; }

    [JsonPropertyName("collection")]
    public string Collection { get; set; }

    [JsonPropertyName("filter")]
    public T Filter { get; set; }
}