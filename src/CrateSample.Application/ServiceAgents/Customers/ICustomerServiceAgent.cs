using CrateSample.Domain.Entities;

namespace CrateSample.Application.ServiceAgents.Customers;

public interface ICustomerServiceAgent
{
    Task<IReadOnlyCollection<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default);
}