using MosaicCRM.Core.Modularity.Abstractions;
using MosaicCRM.Core.Collections;

namespace MosaicCRM.Core.Modularity;

public class CrmModuleLifecycleOptions
{
    public ITypeList<IModuleLifecycleContributor> Contributors { get; }

    public CrmModuleLifecycleOptions()
    {
        Contributors = new TypeList<IModuleLifecycleContributor>();
    }
}