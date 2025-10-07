using CrateSample.Application.Dto;
using CrateSample.Domain.Entities;

namespace CrateSample.Application.Factories;

public interface ICustomerOrderFactory
{
    OrderListing BuildListing(Customer customer, IEnumerable<Order> orders);
    OrderDetail BuildDetail(Customer customer, Order order);
}