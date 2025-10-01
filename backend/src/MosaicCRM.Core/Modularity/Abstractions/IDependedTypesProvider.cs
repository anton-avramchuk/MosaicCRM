using System;

namespace MosaicCRM.Core.Modularity.Abstractions;

public interface IDependedTypesProvider
{

    Type[] GetDependedTypes();
}