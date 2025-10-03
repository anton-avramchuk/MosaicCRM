using MosaicCRM.Core.DataAccess.Abstractions;
using MosaicCRM.Core.Extensions.Collections;
using MosaicCRM.Core.Extensions.DependencyInjection;
using MosaicCRM.Core.Modularity;
using Microsoft.Extensions.DependencyInjection;


namespace MosaicCRM.Core.DataAccess;

[DependsOn]
public partial class DataAccessModule : CrmModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AutoAddDataSeedContributors(context.Services);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        
        var configuration = context.Services.GetConfiguration();

        Configure<CrmDbConnectionOptions>(configuration);

        context.Services.AddSingleton(typeof(IDataFilter<>), typeof(DataFilter<>));
    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        Configure<CrmDbConnectionOptions>(options =>
        {
            options.Databases.RefreshIndexes();
        });
    }

    private static void AutoAddDataSeedContributors(IServiceCollection services)
    {
        var contributors = new List<Type>();

        services.OnRegistered(context =>
        {
            if (typeof(IDataSeedContributor).IsAssignableFrom(context.ImplementationType))
            {
                contributors.Add(context.ImplementationType);
            }
        });

        services.Configure<CrmDataSeedOptions>(options =>
        {
            options.Contributors.AddIfNotContains(contributors);
        });
    }
}