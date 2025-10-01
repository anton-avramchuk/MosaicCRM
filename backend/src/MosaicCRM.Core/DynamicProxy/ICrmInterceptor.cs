namespace MosaicCRM.Core.DynamicProxy;

public interface ICrmInterceptor
{
    Task InterceptAsync(ICrmMethodInvocation invocation);
}