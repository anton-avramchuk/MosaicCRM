using MosaicCRM.Core;

namespace MosaicCRM.Core.Modularity.Abstractions;

public interface IOnPostApplicationInitialization
{
    Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context);

    void OnPostApplicationInitialization(ApplicationInitializationContext context);
}