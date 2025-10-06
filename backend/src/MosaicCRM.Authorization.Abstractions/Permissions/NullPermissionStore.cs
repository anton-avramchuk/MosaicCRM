using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Authorization.Abstractions.Permissions;
[Export(LifetimeType.Singleton,typeof(IPermissionStore))]
public class NullPermissionStore : IPermissionStore
{
    //todo: uncomment
    //public ILogger<NullPermissionStore> Logger { get; set; }

    public NullPermissionStore()
    {
        //Logger = NullLogger<NullPermissionStore>.Instance;
    }

    public Task<bool> IsGrantedAsync(string name, string providerName, string providerKey)
    {
        return Task.FromResult(false);
    }

    public Task<MultiplePermissionGrantResult> IsGrantedAsync(string[] names, string providerName, string providerKey)
    {
        return Task.FromResult(new MultiplePermissionGrantResult(names, PermissionGrantResult.Prohibited));
    }
}