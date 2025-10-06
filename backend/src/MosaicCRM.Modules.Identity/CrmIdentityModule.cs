using MosaicCRM.Core.Modularity;
using MosaicCRM.EntityFramework;
using MosaicCRM.Modules.Identity.Domain;
using MosaicCRM.Security;

namespace MosaicCRM.Modules.Identity;

[DependsOn(typeof(CrmIdentityDomainModule), typeof(EntityFrameworkModule), typeof(SecurityModule))]
public class CrmIdentityModule : CrmModule
{
}