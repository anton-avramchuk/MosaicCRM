using MosaicCRM.Core.Modularity;

namespace MosaicCRM.Security;

public partial class SecurityModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}