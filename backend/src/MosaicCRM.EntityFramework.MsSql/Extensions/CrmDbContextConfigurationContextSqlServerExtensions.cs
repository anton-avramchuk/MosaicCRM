using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MosaicCRM.EntityFramework.MsSql.Extensions;

public static class CrmDbContextConfigurationContextSqlServerExtensions
{
    public static DbContextOptionsBuilder UseSqlServer(
        this CrmDbContextConfigurationContext context,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseSqlServer(context.ExistingConnection, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqlServerOptionsAction?.Invoke(optionsBuilder);
            });
        }
        else
        {
            return context.DbContextOptions.UseSqlServer(context.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqlServerOptionsAction?.Invoke(optionsBuilder);
            });
        }
    }
}