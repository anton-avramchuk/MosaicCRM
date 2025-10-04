using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.OpenApi.Services;

namespace MosaicCRM.OpenApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenApiAggregator(this IServiceCollection services)
    {
        services.AddSingleton<IOpenApiAggregator, OpenApiAggregator>();

        return services;
    }
}