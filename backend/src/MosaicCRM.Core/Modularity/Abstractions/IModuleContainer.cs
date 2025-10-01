namespace MosaicCRM.Core.Modularity.Abstractions;

public interface IModuleContainer
{

    IReadOnlyList<ICrmModuleDescriptor> Modules { get; }
}