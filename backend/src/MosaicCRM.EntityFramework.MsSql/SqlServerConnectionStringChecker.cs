using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MosaicCRM.Core.DataAccess;
using MosaicCRM.Core.DataAccess.Abstractions;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.EntityFramework.MsSql;

[Dependency(ReplaceServices = true)]
[Export(LifetimeType.Transient, typeof(IConnectionStringChecker))]
public class SqlServerConnectionStringChecker(ILogger<SqlServerConnectionStringChecker> logger)
    : IConnectionStringChecker
{
    private readonly ILogger<SqlServerConnectionStringChecker> _logger = logger;

    public async Task<CrmConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        var result = new CrmConnectionStringCheckResult();
        var connString = new SqlConnectionStringBuilder(connectionString)
        {
            ConnectTimeout = 1
        };

        var oldDatabaseName = connString.InitialCatalog;
        connString.InitialCatalog = "master";

        try
        {
            await using var conn = new SqlConnection(connString.ConnectionString);
            await conn.OpenAsync();
            result.Connected = true;
            await conn.ChangeDatabaseAsync(oldDatabaseName);
            result.DatabaseExists = true;

            await conn.CloseAsync();

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return result;
        }
    }
}