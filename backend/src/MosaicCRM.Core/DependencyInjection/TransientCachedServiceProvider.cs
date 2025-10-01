namespace MosaicCRM.Core.DependencyInjection;

[Export(LifetimeType.Transient, typeof(ITransientCachedServiceProvider))]
public class TransientCachedServiceProvider :
    CachedServiceProviderBase,
    ITransientCachedServiceProvider
{
    public TransientCachedServiceProvider(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }
}