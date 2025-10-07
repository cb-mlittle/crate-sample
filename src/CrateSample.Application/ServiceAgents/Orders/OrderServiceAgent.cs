using System.Text.Json;

using CrateSample.Domain.Entities;

namespace CrateSample.Application.ServiceAgents.Orders;

internal class OrderServiceAgent : IOrderServiceAgent
{
    private readonly IOrderClient _orderClient;

    public OrderServiceAgent(IOrderClient orderClient)
    {
        _orderClient = orderClient;
    }

    public async Task<IReadOnlyCollection<Order>> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        var response =
            await _orderClient.GetOrdersAsync(cancellationToken)
                .ConfigureAwait(false);

        var responseStream =
            await response.Content
                .ReadAsStreamAsync(cancellationToken)
                .ConfigureAwait(false);

        var typedResponse =
            await JsonSerializer.DeserializeAsync<IReadOnlyCollection<Order>>
                (
                    responseStream,
                    JsonSerializerOptions.Default,
                    cancellationToken
                )
                .ConfigureAwait(false);

        return typedResponse!;
    }
}