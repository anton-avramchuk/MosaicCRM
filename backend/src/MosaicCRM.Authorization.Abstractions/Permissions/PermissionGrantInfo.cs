namespace MosaicCRM.Authorization.Abstractions.Permissions;

public class PermissionGrantInfo(string name, bool isGranted, string? providerName = null, string? providerKey = null)
{
    public string Name { get; } = name;

    public bool IsGranted { get; } = isGranted;

    public string? ProviderName { get; } = providerName;

    public string? ProviderKey { get; } = providerKey;
}