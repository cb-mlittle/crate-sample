using System.Text.Json;

using CrateSample.Domain.Entities;

namespace CrateSample.Application.ServiceAgents.Customers;

internal class CustomerServiceAgent : ICustomerServiceAgent
{
    private readonly ICustomerClient _customerClient;

    public CustomerServiceAgent(ICustomerClient customerClient)
    {
        _customerClient = customerClient;
    }

    public async Task<IReadOnlyCollection<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default)
    {
        var response =
            await _customerClient.GetCustomersAsync(cancellationToken)
                .ConfigureAwait(false);

        var responseStream =
            await response.Content
                .ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);

        var typedResponse =
            await JsonSerializer.DeserializeAsync<IReadOnlyCollection<Customer>>
                (
                    responseStream,
                    JsonSerializerOptions.Default,
                    cancellationToken
                )
                .ConfigureAwait(false);

        return typedResponse!;
    }
}