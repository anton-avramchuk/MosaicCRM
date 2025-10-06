using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.Core.SimpleStateChecking;
using MosaicCRM.Security.Users.Abstractions;

namespace MosaicCRM.Authorization.Permissions;

public class RequireAuthenticatedSimpleStateChecker<TState> : ISimpleStateChecker<TState>
    where TState : IHasSimpleStateCheckers<TState>
{
    public Task<bool> IsEnabledAsync(SimpleStateCheckerContext<TState> context)
    {
        return Task.FromResult(context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated);
    }
}