namespace CrateSample.Application.Services.Configuration;

public interface IConfigurationService
{
    T GetValue<T>(string key, T defaultValue = default!, bool throwOnFail = false)
        where T : IConvertible;

    bool TryGetRawValue(string key, out object value);

    void Override<T>(string key, T value)
        where T : IConvertible;
}