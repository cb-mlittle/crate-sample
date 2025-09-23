using CrateSample.Application.Services.Configuration;

namespace CrateSample.Application.Configuration;

public sealed class SharedConfiguration : ConfigurationExtensionBase
{
    public SharedConfiguration(IConfigurationService configurationService)
        : base(string.Empty, configurationService)
    {
    }

    public bool DebugEnabled
    {
        get { return GetValue<bool>(); }
    }
}