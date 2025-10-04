using System.Security.Claims;
using MosaicCRM.Core.DependencyInjection;
using MosaicCRM.Security.Claims.Abstractions;

namespace MosaicCRM.Security.Claims;

[Export(LifetimeType.Singleton,typeof(ICurrentPrincipalAccessor))]
public class ThreadCurrentPrincipalAccessor : CurrentPrincipalAccessorBase
{
    protected override ClaimsPrincipal? GetClaimsPrincipal()
    {
        return Thread.CurrentPrincipal as ClaimsPrincipal;
    }
}