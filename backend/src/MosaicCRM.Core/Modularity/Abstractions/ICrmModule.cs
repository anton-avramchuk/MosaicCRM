namespace MosaicCRM.Core.Modularity.Abstractions;

public interface ICrmModule
{
    Task ConfigureServicesAsync(ServiceConfigurationContext context);

    void ConfigureServices(ServiceConfigurationContext context);
}