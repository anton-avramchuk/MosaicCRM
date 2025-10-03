using Microsoft.Extensions.DependencyInjection.Extensions;
using MosaicCRM.Core.DataAccess;
using MosaicCRM.Core.Modularity;
using MosaicCRM.Domain;
using MosaicCRM.EntityFramework.Providers;

namespace MosaicCRM.EntityFramework;

[DependsOn(typeof(CrmDomainModule),typeof(DataAccessModule))]
public partial class EntityFrameworkModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        context.Services.TryAddTransient(typeof(IDbContextProvider<>), typeof(DbContextProvider<>));
    }
}