using System.Text.Json.Serialization;

namespace CrateSample.Domain.Entities;

public class Order
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    public Guid CustomerId { get; set; }

    [JsonPropertyName("items")]
    public OrderItem[] Items { get; set; } = [];

    [JsonPropertyName("total_amount")]
    public decimal TotalAmount { get; set; }

    [JsonPropertyName("order_date")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}