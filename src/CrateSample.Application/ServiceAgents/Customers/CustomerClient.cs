namespace CrateSample.Application.ServiceAgents.Customers;

internal class CustomerClient : ICustomerClient
{
    private readonly HttpClient _httpClient;

    public CustomerClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> GetCustomersAsync(CancellationToken cancellationToken = default)
    {
        var requestUri = new Uri("http://localhost:5063/customers.json");

        return _httpClient.GetAsync(requestUri, cancellationToken);
    }
}