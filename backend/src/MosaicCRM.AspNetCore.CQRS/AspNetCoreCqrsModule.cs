using MosaicCRM.AspNetCore.Responses;
using MosaicCRM.Core.Modularity;

namespace MosaicCRM.AspNetCore.CQRS;

[DependsOn(typeof(AspNetCoreModule),typeof(AspNetCoreResponsesModule))]
public class AspNetCoreCqrsModule:CrmModule
{
}