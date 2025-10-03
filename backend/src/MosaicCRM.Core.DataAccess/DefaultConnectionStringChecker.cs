using MosaicCRM.Core.DataAccess.Abstractions;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Core.DataAccess;

[Export(LifetimeType.Transient,typeof(IConnectionStringChecker))]
public class DefaultConnectionStringChecker : IConnectionStringChecker
{
    public Task<CrmConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        return Task.FromResult(new CrmConnectionStringCheckResult
        {
            Connected = false,
            DatabaseExists = false
        });
    }
}