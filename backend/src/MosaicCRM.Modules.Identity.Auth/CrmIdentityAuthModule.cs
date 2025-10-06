using MosaicCRM.Core.Modularity;
using MosaicCRM.Modules.Identity.Domain;

namespace MosaicCRM.Modules.Identity.Auth;

[DependsOn(typeof(CrmIdentityModule), typeof(CrmIdentityDomainModule))]
public class CrmIdentityAuthModule : CrmModule
{
}