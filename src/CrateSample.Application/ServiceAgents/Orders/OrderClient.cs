namespace CrateSample.Application.ServiceAgents.Orders;

internal class OrderClient : IOrderClient
{
    private readonly HttpClient _httpClient;

    public OrderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        var requestUri = new Uri("http://localhost:5063/orders.json");

        return _httpClient.GetAsync(requestUri, cancellationToken);
    }
}