namespace CrateSample.Application.Dto;

public class OrderInfo
{
    public string? OrderNumber { get; set; }
    public decimal OrderTotal { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderStatus { get; set; }
}