using System.Text.Json.Serialization;

namespace CrateSample.Domain.Entities;

public class Customer
{
    [JsonPropertyName("profile_id")]
    public Guid ProfileId { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}