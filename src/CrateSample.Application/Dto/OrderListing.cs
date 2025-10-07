namespace CrateSample.Application.Dto;

public class OrderListing
{
    public OrderCustomer? Customer { get; set; }
    public IReadOnlyCollection<OrderInfo>? Orders { get; set; }
}