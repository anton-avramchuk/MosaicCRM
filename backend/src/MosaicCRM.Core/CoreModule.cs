using MosaicCRM.Core.Modularity;

namespace MosaicCRM.Core;

public partial class CoreModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}