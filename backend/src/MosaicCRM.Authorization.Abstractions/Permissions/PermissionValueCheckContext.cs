using System.Security.Claims;

namespace MosaicCRM.Authorization.Abstractions.Permissions;

public class PermissionValueCheckContext
{

    public PermissionDefinition Permission { get; }

    public ClaimsPrincipal? Principal { get; }

    public PermissionValueCheckContext(
        PermissionDefinition permission,
        ClaimsPrincipal? principal)
    {
        Permission = permission;
        Principal = principal;
    }
}