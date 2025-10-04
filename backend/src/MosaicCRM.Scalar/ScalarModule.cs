using Microsoft.AspNetCore.Builder;
using MosaicCRM.AspNetCore;
using MosaicCRM.AspNetCore.Extensions;
using MosaicCRM.Core;
using MosaicCRM.Core.Modularity;
using Scalar.AspNetCore;

namespace MosaicCRM.Scalar;

[DependsOn(typeof(AspNetCoreModule))]
public partial class ScalarModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }


    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var routeBuilder = context.GetRouteBuilder();
        routeBuilder.MapGet("/", httpContext =>
        {
            httpContext.Response.Redirect("/scalar", permanent: false);
            return Task.CompletedTask;
        });


        var options = context.GetOptions<ScalarModuleOptions>();


        routeBuilder.MapScalarApiReference(w =>
        {
            if (!string.IsNullOrWhiteSpace(options.OpenApiPath))
            {
                w.OpenApiRoutePattern = options.OpenApiPath;
            }
        });
    }
}