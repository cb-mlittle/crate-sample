using CrateSample.Domain.Entities;

namespace CrateSample.Application.ServiceAgents.Orders;

public interface IOrderServiceAgent
{
    Task<IReadOnlyCollection<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);
}