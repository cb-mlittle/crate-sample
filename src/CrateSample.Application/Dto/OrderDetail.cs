namespace CrateSample.Application.Dto;

public class OrderDetail
{
    public OrderCustomer? Customer { get; set; }
    public OrderInfo? Info { get; set; }
    public IReadOnlyCollection<OrderDetailItem> Items { get; set; } = [];
}