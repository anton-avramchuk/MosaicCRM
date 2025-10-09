using MosaicCRM.AspNetCore.Extensions;
using MosaicCRM.Core;
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

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        app.UseRouting();

    }
}