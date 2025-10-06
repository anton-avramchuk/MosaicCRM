using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MosaicCRM.Authorization.Abstractions;
using MosaicCRM.Core.DependencyInjection;
using MosaicCRM.Security.Claims.Abstractions;

namespace MosaicCRM.Authorization;

[Dependency(ReplaceServices = true)]
[Export(LifetimeType.Transient,typeof(ICrmAuthorizationService))]
public class CrmAuthorizationService : DefaultAuthorizationService, ICrmAuthorizationService
{
    public IServiceProvider ServiceProvider { get; }

    public ClaimsPrincipal CurrentPrincipal => _currentPrincipalAccessor.Principal;

    private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;

    public CrmAuthorizationService(
        IAuthorizationPolicyProvider policyProvider,
        IAuthorizationHandlerProvider handlers,
        ILogger<DefaultAuthorizationService> logger,
        IAuthorizationHandlerContextFactory contextFactory,
        IAuthorizationEvaluator evaluator,
        IOptions<AuthorizationOptions> options,
        ICurrentPrincipalAccessor currentPrincipalAccessor,
        IServiceProvider serviceProvider)
        : base(
            policyProvider,
            handlers,
            logger,
            contextFactory,
            evaluator,
            options)
    {
        _currentPrincipalAccessor = currentPrincipalAccessor;
        ServiceProvider = serviceProvider;
    }
}