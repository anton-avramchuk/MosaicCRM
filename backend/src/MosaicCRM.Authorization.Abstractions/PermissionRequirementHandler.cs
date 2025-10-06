using Microsoft.AspNetCore.Authorization;
using MosaicCRM.Authorization.Abstractions.Permissions;

namespace MosaicCRM.Authorization.Abstractions;

public class PermissionRequirementHandler(IPermissionChecker permissionChecker)
    : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (await permissionChecker.IsGrantedAsync(context.User, requirement.PermissionName))
        {
            context.Succeed(requirement);
        }
    }
}