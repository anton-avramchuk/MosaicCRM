using MosaicCRM.AspNetCore.Jwt;
using MosaicCRM.Core.Modularity;
using MosaicCRM.Modules.Identity.AspNetCore.Jwt.Options;
using MosaicCRM.Modules.Identity.Auth;
using MosaicCRM.Modules.Identity.Domain;
using MosaicCRM.Security;

namespace MosaicCRM.Modules.Identity.AspNetCore.Jwt;

[DependsOn(typeof(AspNetCoreJwtModule), typeof(CrmIdentityModule), typeof(CrmIdentityAuthModule),
    typeof(CrmIdentityDomainModule), typeof(SecurityModule))]
public class AspNetCoreIdentityJwtModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<JwtConfiguration>(w =>
        {
            w.TokenLifetimeMinutes = 24 * 60;
            w.Secret = "12345678";
        });
    }
}