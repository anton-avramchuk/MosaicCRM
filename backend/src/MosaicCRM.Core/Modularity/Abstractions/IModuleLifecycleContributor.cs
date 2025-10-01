using MosaicCRM.Core;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Core.Modularity.Abstractions;

public interface IModuleLifecycleContributor : ITransientDependency
{
    Task InitializeAsync(ApplicationInitializationContext context, ICrmModule module);

    void Initialize(ApplicationInitializationContext context, ICrmModule module);

    Task ShutdownAsync(ApplicationShutdownContext context, ICrmModule module);

    void Shutdown(ApplicationShutdownContext context, ICrmModule module);
}