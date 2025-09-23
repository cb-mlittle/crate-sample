using Microsoft.Extensions.Configuration;

namespace CrateSample.Application.Services.Configuration;

internal class ScopedConfigurationService : IConfigurationService
{
    private readonly IConfiguration _configuration;
    private readonly IDictionary<string, object> _overrides;

    public ScopedConfigurationService(IConfiguration configuration)
    {
        _configuration = configuration;
        _overrides = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    }

    public T GetValue<T>(string key, T defaultValue = default!, bool throwOnFail = false)
        where T : IConvertible
    {
        if (TryGetRawValue(key, out var value))
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        if (throwOnFail)
        {
            throw new KeyNotFoundException($"{key} not found in configuration source.");
        }

        return defaultValue;
    }

    public bool TryGetRawValue(string key, out object value)
    {
        return _overrides.TryGetValue(key, out value!) || TryGetGlobalValue(out value);

        bool TryGetGlobalValue(out object value)
        {
            var globalConfiguration = _configuration.GetSection(key);

            value = globalConfiguration.Value!;

            return globalConfiguration.Exists();
        }
    }

    public void Override<T>(string key, T value)
        where T : IConvertible
    {
        _overrides[key] = value;
    }
}