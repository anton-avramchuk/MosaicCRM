using MosaicCRM.Core.Modularity.Abstractions;
using MosaicCRM.Core;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Core.Modularity;

[Export(LifetimeType.Transient)]
public class OnApplicationInitializationModuleLifecycleContributor : ModuleLifecycleContributorBase
{
    public override async Task InitializeAsync(ApplicationInitializationContext context, ICrmModule module)
    {
        if (module is IOnApplicationInitialization onApplicationInitialization)
        {
            await onApplicationInitialization.OnApplicationInitializationAsync(context);
        }
    }

    public override void Initialize(ApplicationInitializationContext context, ICrmModule module)
    {
        (module as IOnApplicationInitialization)?.OnApplicationInitialization(context);
    }
}