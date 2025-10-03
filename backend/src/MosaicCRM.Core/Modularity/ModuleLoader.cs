using MosaicCRM.Core.Extensions.Collections;
using MosaicCRM.Core.Extensions.DependencyInjection;
using MosaicCRM.Core.Modularity.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.Core;
using MosaicCRM.Core.Exceptions;

namespace MosaicCRM.Core.Modularity;

public class ModuleLoader : IModuleLoader
{
    public ICrmModuleDescriptor[] LoadModules(
        IServiceCollection services,
        Type startupModuleType)
    {

        return ModuleInitializer.Modules.Select(x => CreateModuleDescriptor(services, x)).ToArray();
    }


    private ICrmModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType)
    {
        return new CrmModuleDescriptor(moduleType, CreateAndRegisterModule(services, moduleType));
    }

    private ICrmModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
    {
        var module = (ICrmModule)Activator.CreateInstance(moduleType)!;
        services.AddSingleton(moduleType, module);
        return module;
    }
}