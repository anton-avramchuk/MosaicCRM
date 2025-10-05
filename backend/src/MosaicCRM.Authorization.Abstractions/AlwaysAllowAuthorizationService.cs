using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MosaicCRM.Security.Claims.Abstractions;

namespace MosaicCRM.Authorization.Abstractions;

public class AlwaysAllowAuthorizationService(
    IServiceProvider serviceProvider,
    ICurrentPrincipalAccessor currentPrincipalAccessor)
    : ICrmAuthorizationService
{
    public IServiceProvider ServiceProvider { get; } = serviceProvider;

    public ClaimsPrincipal? CurrentPrincipal => currentPrincipalAccessor.Principal;

    public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object? resource, IEnumerable<IAuthorizationRequirement> requirements)
    {
        return Task.FromResult(AuthorizationResult.Success());
    }

    public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object? resource, string policyName)
    {
        return Task.FromResult(AuthorizationResult.Success());
    }
}