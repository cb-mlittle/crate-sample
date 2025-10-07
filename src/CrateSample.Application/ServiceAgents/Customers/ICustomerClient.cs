namespace CrateSample.Application.ServiceAgents.Customers;

public interface ICustomerClient
{
    Task<HttpResponseMessage> GetCustomersAsync(CancellationToken cancellationToken = default);
}