using Microsoft.Extensions.DependencyInjection;

namespace MosaicCRM.Core.Modularity.Abstractions;

public interface IModuleLoader
{

    ICrmModuleDescriptor[] LoadModules(
        IServiceCollection services,
        Type startupModuleType
    );
}