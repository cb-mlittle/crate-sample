using CrateSample.Application.Dto;

namespace CrateSample.Application.Services.CustomerOrders;

public interface ICustomerOrderService
{
    Task<IReadOnlyCollection<OrderListing>> GetOrderListings();
    Task<IReadOnlyCollection<OrderDetail>> GetOrderDetails(string orderId);
}