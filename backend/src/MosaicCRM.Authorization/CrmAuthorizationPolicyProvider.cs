using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MosaicCRM.Authorization.Abstractions;
using MosaicCRM.Authorization.Abstractions.Permissions;
using MosaicCRM.Authorization.Extensions;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Authorization;

[Export(LifetimeType.Transient,typeof(ICrmAuthorizationPolicyProvider))]
public class CrmAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider, ICrmAuthorizationPolicyProvider
{
    private readonly AuthorizationOptions _options;
    private readonly IPermissionDefinitionManager _permissionDefinitionManager;

    public CrmAuthorizationPolicyProvider(
        IOptions<AuthorizationOptions> options,
        IPermissionDefinitionManager permissionDefinitionManager)
        : base(options)
    {
        _permissionDefinitionManager = permissionDefinitionManager;
        _options = options.Value;
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        if (policy != null)
        {
            return policy;
        }

        var permission = await _permissionDefinitionManager.GetOrNullAsync(policyName);
        if (permission != null)
        {
            //TODO: Optimize & Cache!
            var policyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
            policyBuilder.Requirements.Add(new PermissionRequirement(policyName));
            return policyBuilder.Build();
        }

        return null;
    }

    public async Task<List<string>> GetPoliciesNamesAsync()
    {
        return _options.GetPoliciesNames()
            .Union(
                (await _permissionDefinitionManager
                    .GetPermissionsAsync())
                .Select(p => p.Name)
            )
            .ToList();
    }
}