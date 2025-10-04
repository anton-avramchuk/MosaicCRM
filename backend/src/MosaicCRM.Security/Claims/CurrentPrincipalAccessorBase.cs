using System.Security.Claims;
using MosaicCRM.Core;
using MosaicCRM.Security.Claims.Abstractions;

namespace MosaicCRM.Security.Claims;

public abstract class CurrentPrincipalAccessorBase : ICurrentPrincipalAccessor
{
    public ClaimsPrincipal Principal => _currentPrincipal.Value ?? GetClaimsPrincipal();

    private readonly AsyncLocal<ClaimsPrincipal> _currentPrincipal = new();

    protected abstract ClaimsPrincipal? GetClaimsPrincipal();

    public virtual IDisposable Change(ClaimsPrincipal principal)
    {
        return SetCurrent(principal);
    }

    private IDisposable SetCurrent(ClaimsPrincipal principal)
    {
        var parent = Principal;
        _currentPrincipal.Value = principal;
        return new DisposeAction(() =>
        {
            _currentPrincipal.Value = parent;
        });
    }
}