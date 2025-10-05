using MosaicCRM.Core.Modularity;

namespace MosaicCRM.EntityFramework.MsSql;

[DependsOn(typeof(EntityFrameworkModule))]
public partial class EntityFrameworkCoreSqlServerModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}