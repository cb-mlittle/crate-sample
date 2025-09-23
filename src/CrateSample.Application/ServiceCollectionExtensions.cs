using CrateSample.Application.Services.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace CrateSample.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddConfiguration();

        return services;
    }

    private static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IConfigurationService, ScopedConfigurationService>();

        return services;
    }
}