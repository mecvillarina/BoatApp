using System.Text.Json.Serialization;

namespace BoatApp.Models.Contracts;

public class OwnerContract
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("contact")]
    public string Contact { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("address")]
    public OwnerAddressContract Address { get; set; }

    [JsonPropertyName("profile_pic")]
    public string ProfilePic { get; set; }

    [JsonPropertyName("member_since")]
    public string MemberSince { get; set; }
}