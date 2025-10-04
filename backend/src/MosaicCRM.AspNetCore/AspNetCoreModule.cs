using MosaicCRM.Core.Extensions.DependencyInjection;
using MosaicCRM.Core.Modularity;
using MosaicCRM.Security;

namespace MosaicCRM.AspNetCore;

[DependsOn(typeof(SecurityModule))]
public partial class AspNetCoreModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        context.Services.AddHttpContextAccessor();
        context.Services.AddObjectAccessor<IApplicationBuilder>();
        context.Services.AddObjectAccessor<IEndpointRouteBuilder>();
    }
}