using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.AspNetCore;
using MosaicCRM.AspNetCore.Extensions;
using MosaicCRM.Core;
using MosaicCRM.Core.Modularity;

namespace MosaicCRM.OpenApi;

[DependsOn(typeof(AspNetCoreModule))]
public partial class OpenApiModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        context.Services.AddOpenApi();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var routeBuilder = context.GetRouteBuilder();
        routeBuilder.MapOpenApi();
    }
}