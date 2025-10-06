using MosaicCRM.Core.Collections;

namespace MosaicCRM.Authorization.Abstractions.Permissions;

public class CrmPermissionOptions
{
    public ITypeList<IPermissionDefinitionProvider> DefinitionProviders { get; } = new TypeList<IPermissionDefinitionProvider>();

    public ITypeList<IPermissionValueProvider> ValueProviders { get; } = new TypeList<IPermissionValueProvider>();

    public HashSet<string> DeletedPermissions { get; } = new();

    public HashSet<string> DeletedPermissionGroups { get; } = new();
}