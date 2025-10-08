using CrateSample.Application.Dto;
using CrateSample.Application.Factories;
using CrateSample.Application.ServiceAgents.Customers;
using CrateSample.Application.ServiceAgents.Orders;
using CrateSample.Domain.Entities;

namespace CrateSample.Application.Services.CustomerOrders;

internal class CustomerOrderService : ICustomerOrderService
{
    private readonly ICustomerServiceAgent _customerServiceAgent;
    private readonly IOrderServiceAgent _orderServiceAgent;
    private readonly ICustomerOrderFactory _customerOrderFactory;

    public CustomerOrderService(
        ICustomerServiceAgent customerServiceAgent,
        IOrderServiceAgent orderServiceAgent,
        ICustomerOrderFactory customerOrderFactory)
    {
        _customerServiceAgent = customerServiceAgent;
        _orderServiceAgent = orderServiceAgent;
        _customerOrderFactory = customerOrderFactory;
    }

    public Task<IReadOnlyCollection<OrderListing>> GetOrderListings() =>
        GetOrderListings(profileIds: null);

    public Task<IReadOnlyCollection<OrderListing>> GetOrderListings(IEnumerable<Guid>? profileIds)
    {
        IReadOnlyCollection<OrderListing> empty = Array.Empty<OrderListing>();
        return Task.FromResult(empty);
    }

    public Task<IReadOnlyCollection<OrderDetail>> GetOrderDetails(string orderId)
    {
        IReadOnlyCollection<OrderDetail> empty = Array.Empty<OrderDetail>();
        return Task.FromResult(empty);
    }
}
