using CrateSample.Application.Dto;
using CrateSample.Domain.Entities;

namespace CrateSample.Application.Factories;

internal class CustomerOrderFactory : ICustomerOrderFactory
{
    public OrderListing BuildListing(Customer customer, IEnumerable<Order> orders)
    {
        var orderListing =
            new OrderListing
            {
                Customer =
                    new OrderCustomer
                    {
                        CustomerFirstName = customer.FirstName,
                        CustomerLastName = customer.LastName
                    },
                Orders =
                    orders.Select
                        (
                            order =>
                                new OrderInfo
                                {
                                    OrderDate = order.OrderDate,
                                    OrderNumber = order.OrderId,
                                    OrderStatus = order.Status,
                                    OrderTotal = order.TotalAmount
                                }
                        )
                        .ToList()
            };

        return orderListing;
    }

    public OrderDetail BuildDetail(Customer customer, Order order)
    {
        var orderDetail =
            new OrderDetail
            {
                Customer =
                    new OrderCustomer
                    {
                        CustomerFirstName = customer.FirstName,
                        CustomerLastName = customer.LastName
                    },
                Info =
                    new OrderInfo
                    {
                        OrderDate = order.OrderDate,
                        OrderNumber = order.OrderId,
                        OrderStatus = order.Status,
                        OrderTotal = order.TotalAmount
                    },
                Items =
                    order.Items
                        .Select
                        (
                            item =>
                                new OrderDetailItem
                                {
                                    ItemId = item.ProductId,
                                    ItemName = item.Name,
                                    ItemPrice = item.Price,
                                    ItemQuantity = item.Quantity
                                }
                        )
                        .ToList()
            };

        return orderDetail;
    }
}