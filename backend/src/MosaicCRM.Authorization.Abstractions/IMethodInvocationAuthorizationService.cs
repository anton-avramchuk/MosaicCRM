namespace MosaicCRM.Authorization.Abstractions;

public interface IMethodInvocationAuthorizationService
{
    Task CheckAsync(MethodInvocationAuthorizationContext context);
}