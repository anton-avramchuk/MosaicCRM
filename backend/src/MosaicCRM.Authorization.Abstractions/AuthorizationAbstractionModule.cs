using MosaicCRM.Core.Modularity;
using MosaicCRM.Security;

namespace MosaicCRM.Authorization.Abstractions;

[DependsOn(typeof(SecurityModule))]
public partial class AuthorizationAbstractionModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}