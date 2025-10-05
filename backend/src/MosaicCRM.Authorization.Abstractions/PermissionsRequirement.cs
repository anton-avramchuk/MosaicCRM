using Microsoft.AspNetCore.Authorization;

namespace MosaicCRM.Authorization.Abstractions;

public class PermissionsRequirement(string[] permissionNames, bool requiresAll) : IAuthorizationRequirement
{
    public string[] PermissionNames { get; } = permissionNames;

    public bool RequiresAll { get; } = requiresAll;

    public override string ToString()
    {
        return $"PermissionsRequirement: {string.Join(", ", PermissionNames)}";
    }
}