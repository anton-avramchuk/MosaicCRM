using Microsoft.Extensions.Logging;
using MosaicCRM.Core.DataAccess;
using MosaicCRM.Core.DataAccess.Abstractions;
using MosaicCRM.Core.DependencyInjection;
using Npgsql;

namespace MosaicCRM.EntityFramework.PostgreSql;

[Dependency(ReplaceServices = true)]
[Export(LifetimeType.Transient, typeof(IConnectionStringChecker))]
public class NpgsqlConnectionStringChecker(ILogger<NpgsqlConnectionStringChecker> logger) : IConnectionStringChecker
{
    public async Task<CrmConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        var result = new CrmConnectionStringCheckResult();
        var connString = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Timeout = 1
        };

        var oldDatabaseName = connString.Database;
        connString.Database = "postgres";

        try
        {
            await using var conn = new NpgsqlConnection(connString.ConnectionString);
            await conn.OpenAsync();
            result.Connected = true;
            await conn.ChangeDatabaseAsync(oldDatabaseName!);
            result.DatabaseExists = true;

            await conn.CloseAsync();

            return result;
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return result;
        }
    }
}