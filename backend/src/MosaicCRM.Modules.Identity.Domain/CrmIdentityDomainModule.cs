using MosaicCRM.Core.Modularity;
using MosaicCRM.Domain;

namespace MosaicCRM.Modules.Identity.Domain;

[DependsOn(typeof(CrmDomainModule))]
public class CrmIdentityDomainModule : CrmModule
{
}