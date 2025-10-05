using System.Reflection;

namespace MosaicCRM.Authorization.Abstractions;

public class MethodInvocationAuthorizationContext(MethodInfo method)
{
    public MethodInfo Method { get; } = method;
}