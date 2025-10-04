using System.Security.Claims;

namespace MosaicCRM.Security.Claims.Abstractions;

public interface ICurrentPrincipalAccessor
{
    ClaimsPrincipal? Principal { get; }

    IDisposable Change(ClaimsPrincipal principal);
}