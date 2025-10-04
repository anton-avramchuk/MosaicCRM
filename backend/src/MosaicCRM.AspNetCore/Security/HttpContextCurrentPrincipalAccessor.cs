using System.Security.Claims;
using MosaicCRM.Security.Claims;

namespace MosaicCRM.AspNetCore.Security;

public class HttpContextCurrentPrincipalAccessor(IHttpContextAccessor httpContextAccessor)
    : ThreadCurrentPrincipalAccessor
{
    protected override ClaimsPrincipal? GetClaimsPrincipal()
    {
        return httpContextAccessor.HttpContext?.User ?? base.GetClaimsPrincipal();
    }
}