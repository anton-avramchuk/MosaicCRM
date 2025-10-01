namespace MosaicCRM.Core.DependencyInjection;

[Export(LifetimeType.Scoped, typeof(ICachedServiceProvider))]
public class CachedServiceProvider(IServiceProvider serviceProvider) :
    CachedServiceProviderBase(serviceProvider),
    ICachedServiceProvider;