using MosaicCRM.Core.Extensions.Collections;
using MosaicCRM.Core.Extensions.Common;

namespace MosaicCRM.Core.DataAccess;

public class CrmDbConnectionOptions
{
    public ConnectionStrings ConnectionStrings { get; set; }

    public CrmDatabaseInfoDictionary Databases { get; set; }

    public CrmDbConnectionOptions()
    {
        ConnectionStrings = new ConnectionStrings();
        Databases = new CrmDatabaseInfoDictionary();
    }

    public string? GetConnectionStringOrNull(
        string connectionStringName,
        bool fallbackToDatabaseMappings = true,
        bool fallbackToDefault = true)
    {
        var connectionString = ConnectionStrings.GetOrDefault(connectionStringName);
        if (!connectionString.IsNullOrEmpty())
        {
            return connectionString;
        }

        if (fallbackToDatabaseMappings)
        {
            var database = Databases.GetMappedDatabaseOrNull(connectionStringName);
            if (database != null)
            {
                connectionString = ConnectionStrings.GetOrDefault(database.DatabaseName);
                if (!connectionString.IsNullOrEmpty())
                {
                    return connectionString;
                }
            }
        }

        if (fallbackToDefault)
        {
            connectionString = ConnectionStrings.Default;
            if (!connectionString.IsNullOrWhiteSpace())
            {
                return connectionString;
            }
        }

        return null;
    }
}