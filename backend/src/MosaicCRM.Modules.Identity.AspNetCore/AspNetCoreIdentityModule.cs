using MosaicCRM.AspNetCore;
using MosaicCRM.Core.Modularity;

namespace MosaicCRM.Modules.Identity.AspNetCore;

[DependsOn(typeof(AspNetCoreModule))]
public class AspNetCoreIdentityModule : CrmModule
{
}