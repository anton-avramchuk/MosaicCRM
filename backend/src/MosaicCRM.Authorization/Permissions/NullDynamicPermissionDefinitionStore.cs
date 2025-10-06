using System.Collections.Immutable;
using MosaicCRM.Authorization.Abstractions.Permissions;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Authorization.Permissions;

[Export(LifetimeType.Singleton,typeof(IDynamicPermissionDefinitionStore))]
public class NullDynamicPermissionDefinitionStore : IDynamicPermissionDefinitionStore
{
    private readonly static Task<PermissionDefinition?> CachedPermissionResult = Task.FromResult((PermissionDefinition?)null);

    private readonly static Task<IReadOnlyList<PermissionDefinition>> CachedPermissionsResult =
        Task.FromResult((IReadOnlyList<PermissionDefinition>)Array.Empty<PermissionDefinition>().ToImmutableList());

    private readonly static Task<IReadOnlyList<PermissionGroupDefinition>> CachedGroupsResult =
        Task.FromResult((IReadOnlyList<PermissionGroupDefinition>)Array.Empty<PermissionGroupDefinition>().ToImmutableList());

    public Task<PermissionDefinition?> GetOrNullAsync(string name)
    {
        return CachedPermissionResult;
    }

    public Task<IReadOnlyList<PermissionDefinition>> GetPermissionsAsync()
    {
        return CachedPermissionsResult;
    }

    public Task<IReadOnlyList<PermissionGroupDefinition>> GetGroupsAsync()
    {
        return CachedGroupsResult;
    }
}