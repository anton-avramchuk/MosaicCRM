using System.Security.Claims;

namespace MosaicCRM.Security.Claims.Abstractions;

public interface IApplicationClaimsPrincipalFactory
{
    Task<ClaimsPrincipal> CreateAsync(ClaimsPrincipal? existsClaimsPrincipal = null);
}