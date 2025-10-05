using MosaicCRM.AspNetCore.Extensions;
using MosaicCRM.AspNetCore.Jwt.Extensions;
using MosaicCRM.AspNetCore.Jwt.Options;
using MosaicCRM.Core;
using MosaicCRM.Core.Modularity;

namespace MosaicCRM.AspNetCore.Jwt;

[DependsOn(typeof(AspNetCoreModule))]
public partial class AspNetCoreJwtModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        Configure<JwtAuthOptions>(w => { w.AuthPath = "api/auth/token"; });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        app.UseJwtTokenMiddleware();

        
    }
}