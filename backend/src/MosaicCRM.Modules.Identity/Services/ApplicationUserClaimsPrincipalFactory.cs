using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MosaicCRM.Core.DependencyInjection;
using MosaicCRM.Modules.Identity.Domain;
using MosaicCRM.Security.Claims.Abstractions;

namespace MosaicCRM.Modules.Identity.Services;

[Export(LifetimeType.Transient)]
public class ApplicationUserClaimsPrincipalFactory<TIdentityUser, TIdentityRole> : UserClaimsPrincipalFactory<TIdentityUser, TIdentityRole>
    where TIdentityRole : CrmIdentityRole
    where TIdentityUser : CrmIdentityUser<TIdentityRole>
{
    public ICurrentPrincipalAccessor CurrentPrincipalAccessor { get; }

    public ApplicationUserClaimsPrincipalFactory(
        UserManager<TIdentityUser> userManager,
        RoleManager<TIdentityRole> roleManager,
        IOptions<IdentityOptions> options,
        ICurrentPrincipalAccessor currentPrincipalAccessor
    ) : base(userManager, roleManager, options)
    {
        CurrentPrincipalAccessor = currentPrincipalAccessor;
    }
}