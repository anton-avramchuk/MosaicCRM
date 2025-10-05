using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.Core.Modularity;
using MosaicCRM.ObjectMapping.Abstractions;

namespace MosaicCRM.ObjectMapping.Mapster;

[DependsOn(typeof(CrmObjectMappingModule))]
public class CrmMapsterModule : CrmModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        context.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        context.Services.AddScoped(AddMapper);
    }

    private IObjectMapper AddMapper(IServiceProvider provider)
    {
        var config = provider.GetRequiredService<TypeAdapterConfig>();

        provider.GetServices<IMapsterMappingProfile>()
            .ToList()
            .ForEach(profile => profile.Configure(config));


        return new MapsterObjectMapper(config);
    }
}