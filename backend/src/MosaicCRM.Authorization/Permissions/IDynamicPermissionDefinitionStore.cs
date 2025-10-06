using MosaicCRM.Authorization.Abstractions.Permissions;

namespace MosaicCRM.Authorization.Permissions;

public interface IDynamicPermissionDefinitionStore
{
    Task<PermissionDefinition?> GetOrNullAsync(string name);

    Task<IReadOnlyList<PermissionDefinition>> GetPermissionsAsync();

    Task<IReadOnlyList<PermissionGroupDefinition>> GetGroupsAsync();
}