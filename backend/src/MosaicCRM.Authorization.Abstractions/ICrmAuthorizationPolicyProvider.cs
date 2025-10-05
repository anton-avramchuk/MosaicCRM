using Microsoft.AspNetCore.Authorization;

namespace MosaicCRM.Authorization.Abstractions;

public interface ICrmAuthorizationPolicyProvider : IAuthorizationPolicyProvider
{
    Task<List<string>> GetPoliciesNamesAsync();
}