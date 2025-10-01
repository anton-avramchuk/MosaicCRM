using System.Reflection;

namespace MosaicCRM.Core.Modularity.Abstractions;

public interface IAdditionalModuleAssemblyProvider
{
    Assembly[] GetAssemblies();
}