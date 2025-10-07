using CrateSample.Application.Factories;
using CrateSample.Application.ServiceAgents.Customers;
using CrateSample.Application.ServiceAgents.Orders;
using CrateSample.Application.Services.Configuration;
using CrateSample.Application.Services.CustomerOrders;
using Microsoft.Extensions.DependencyInjection;

namespace CrateSample.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddConfiguration();
        services.AddCustomers();
        services.AddOrders();
        services.AddCustomerOrders();

        return services;
    }

    private static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IConfigurationService, ScopedConfigurationService>();

        return services;
    }

    private static IServiceCollection AddCustomers(this IServiceCollection services)
    {
        services.AddHttpClient<ICustomerClient, CustomerClient>();
        services.AddTransient<ICustomerServiceAgent, CustomerServiceAgent>();

        return services;
    }

    private static IServiceCollection AddOrders(this IServiceCollection services)
    {
        services.AddHttpClient<IOrderClient, OrderClient>();
        services.AddTransient<IOrderServiceAgent, OrderServiceAgent>();

        return services;
    }

    private static IServiceCollection AddCustomerOrders(this IServiceCollection services)
    {
        services.AddTransient<ICustomerOrderFactory, CustomerOrderFactory>();
        services.AddTransient<ICustomerOrderService, CustomerOrderService>();

        return services;
    }
}