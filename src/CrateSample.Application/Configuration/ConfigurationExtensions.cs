using CrateSample.Application.Services.Configuration;

namespace CrateSample.Application.Configuration;

public static class ConfigurationExtensions
{
    public static SharedConfiguration Shared(this IConfigurationService configurationService)
    {
        return new SharedConfiguration(configurationService);
    }
}