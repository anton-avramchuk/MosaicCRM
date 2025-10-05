using MosaicCRM.Core.Modularity;

namespace MosaicCRM.EntityFramework.PostgreSql;

[DependsOn(typeof(EntityFrameworkModule))]
public partial class EntityFrameworkCorePostgreSqlModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}