namespace CrateSample.Application.ServiceAgents.Orders;

public interface IOrderClient
{
    Task<HttpResponseMessage> GetOrdersAsync(CancellationToken cancellationToken = default);
}