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

    public CustomerOrderService
    (
        ICustomerServiceAgent customerServiceAgent,
        IOrderServiceAgent orderServiceAgent,
        ICustomerOrderFactory customerOrderFactory
    )
    {
        _customerServiceAgent = customerServiceAgent;
        _orderServiceAgent = orderServiceAgent;
        _customerOrderFactory = customerOrderFactory;
    }

    public async Task<IReadOnlyCollection<OrderListing>> GetOrderListings()
    {
        var orderData = await GetOrderData().ConfigureAwait(false);

        return
            orderData.Select(item => _customerOrderFactory.BuildListing(item.customer, item.orders))
                .ToList();
    }

    public async Task<IReadOnlyCollection<OrderDetail>> GetOrderDetails(string orderId)
    {
        var orderData = await GetOrderData().ConfigureAwait(false);

        var order =
            orderData.SelectMany(item => item.orders)
                .SingleOrDefault(order => order.OrderId == orderId);

        if (order == null)
        {
            throw new ApplicationException($"Order ID: {orderId} not found");
        }

        return
            orderData.Select(item => _customerOrderFactory.BuildDetail(item.customer, order))
                .ToList();
    }

    private async Task<IReadOnlyCollection<(Customer customer, IEnumerable<Order> orders)>> GetOrderData()
    {
        var customerData =
            await _customerServiceAgent.GetCustomersAsync()
                .ConfigureAwait(false);

        var orderData =
            await _orderServiceAgent.GetOrdersAsync()
                .ConfigureAwait(false);

        var customerOrders =
            customerData.GroupJoin
            (
                orderData,
                customer => customer.CustomerId,
                order => order.CustomerId,
                (customer, orders) => (customer, orders)
            )
            .ToList();

        return customerOrders;
    }
}