using MosaicCRM.Authorization.Abstractions;
using MosaicCRM.Core.DependencyInjection;
using MosaicCRM.Core.DynamicProxy;

namespace MosaicCRM.Authorization;

[Export(LifetimeType.Transient)]
public class AuthorizationInterceptor : CrmInterceptor
{
    private readonly IMethodInvocationAuthorizationService _methodInvocationAuthorizationService;

    public AuthorizationInterceptor(IMethodInvocationAuthorizationService methodInvocationAuthorizationService)
    {
        _methodInvocationAuthorizationService = methodInvocationAuthorizationService;
    }

    public override async Task InterceptAsync(ICrmMethodInvocation invocation)
    {
        await AuthorizeAsync(invocation);
        await invocation.ProceedAsync();
    }

    protected virtual async Task AuthorizeAsync(ICrmMethodInvocation invocation)
    {
        await _methodInvocationAuthorizationService.CheckAsync(
            new MethodInvocationAuthorizationContext(
                invocation.Method
            )
        );
    }
}