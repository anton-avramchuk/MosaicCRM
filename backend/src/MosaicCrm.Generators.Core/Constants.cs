using MosaicCRM.Core;
using MosaicCRM.Core.DependencyInjection;
using MosaicCRM.Core.Modularity;
using MosaicCRM.Core.Modularity.Abstractions;

namespace MosaicCrm.Generators.Core
{
    public static class Constants
    {
        public static string? BoostrapperAttributeName = typeof(BootstrapperAttribute).FullName;

        public static string? ModuleTypeName = typeof(ICrmModule).FullName;

        public static string? ExportAttributeName = typeof(ExportAttribute).FullName;


        public static string? DependsOnAttributeName = typeof(DependsOnAttribute).FullName;
    }
}
