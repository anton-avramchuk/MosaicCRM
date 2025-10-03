namespace MosaicCRM.Core.DataAccess.Abstractions;

public interface IDataSeedContributor
{
    Task SeedAsync(DataSeedContext context);
}