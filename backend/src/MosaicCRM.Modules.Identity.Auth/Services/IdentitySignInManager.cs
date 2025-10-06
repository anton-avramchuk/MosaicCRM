using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MosaicCRM.Modules.Identity.Domain;

namespace MosaicCRM.Modules.Identity.Auth.Services;

public class IdentitySignInManager<TIdentityUser, TIdentityRole> : SignInManager<TIdentityUser>
    where TIdentityUser : CrmIdentityUser<TIdentityRole>
    where TIdentityRole : CrmIdentityRole
{
    public IdentitySignInManager(UserManager<TIdentityUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TIdentityUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TIdentityUser>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<TIdentityUser> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
            
    }
}