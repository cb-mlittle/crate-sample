using CrateSample.Application.Services.Configuration;
using System.Runtime.CompilerServices;

namespace CrateSample.Application.Configuration;

public abstract class ConfigurationExtensionBase
{
    private readonly string _prefix;
    private readonly IConfigurationService _configurationService;

    protected ConfigurationExtensionBase(string prefix, IConfigurationService configurationService)
    {
        _prefix = prefix;
        _configurationService = configurationService;
    }

    protected T GetValue<T>([CallerMemberName] string? key = null)
        where T : IConvertible
    {
        return _configurationService.GetValue<T>(BuildKey(_prefix, key!));
    }

    private static string BuildKey(string prefix, string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key can not be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(prefix))
        {
            return key;
        }

        return $"{prefix}__{key}";
    }
}