using MosaicCRM.Core.Collections;
using MosaicCRM.Core.DynamicProxy;

namespace MosaicCRM.Core.DependencyInjection;

public interface IOnServiceRegistredContext
{
    ITypeList<ICrmInterceptor> Interceptors { get; }
    Type ImplementationType { get; }
}