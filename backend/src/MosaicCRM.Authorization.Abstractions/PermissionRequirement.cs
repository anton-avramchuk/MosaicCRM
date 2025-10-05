using Microsoft.AspNetCore.Authorization;

namespace MosaicCRM.Authorization.Abstractions;

public class PermissionRequirement(string permissionName) : IAuthorizationRequirement
{
    public string PermissionName { get; } = permissionName;

    public override string ToString()
    {
        return $"PermissionRequirement: {PermissionName}";
    }
}