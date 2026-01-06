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

    public async Task<IReadOnlyCollection<OrderListing>> GetOrderListings() =>
        await GetOrderListings(profileIds: null).ConfigureAwait(false);

    public async Task<IReadOnlyCollection<OrderListing>> GetOrderListings(IEnumerable<Guid>? profileIds)
    {
        var orderData = await GetOrderData(profileIds).ConfigureAwait(false);
        return orderData
            .Select(item => _customerOrderFactory.BuildListing(item.customer, item.orders))
            .ToList();
    }

    public async Task<IReadOnlyCollection<OrderDetail>> GetOrderDetails(string orderId)
    {
        var orderData = await GetOrderData().ConfigureAwait(false);
        var order = orderData.SelectMany(item => item.orders)
            .SingleOrDefault(o => o.OrderId == orderId)
            ?? throw new ApplicationException($"Order ID: {orderId} not found");

        return orderData
            .Select(item => _customerOrderFactory.BuildDetail(item.customer, order))
            .DistinctBy(d => d.Info?.OrderNumber)
            .ToList();
    }

    private async Task<IReadOnlyCollection<(Customer customer, IEnumerable<Order> orders)>> GetOrderData(IEnumerable<Guid>? profileIds = null)
    {
        var customerData = await _customerServiceAgent.GetCustomersAsync().ConfigureAwait(false);
        var orderData = await _orderServiceAgent.GetOrdersAsync().ConfigureAwait(false);

        HashSet<Guid>? filter = null;
        if (profileIds != null)
        {
            var list = profileIds as ICollection<Guid> ?? profileIds.ToList();
            if (list.Count > 0)
                filter = new HashSet<Guid>(list);
        }

        if (filter is not null)
        {
            customerData = customerData
                .Where(c => filter.Contains(c.ProfileId))
                .ToList();

            orderData = orderData
                .Where(o => filter.Contains(o.ProfileId))
                .ToList();
        }

        var customerOrders = customerData
            .GroupJoin(
                orderData,
                customer => customer.ProfileId,
                order => order.ProfileId,
                (customer, orders) => (customer, orders))
            .ToList();

        return customerOrders;
    }
}
