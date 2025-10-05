using HornsAndHoovesCrm.Authorization.Abstractions;
using HornsAndHoovesCrm.Authorization.Abstractions.Permissions;
using Microsoft.AspNetCore.Authorization;

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