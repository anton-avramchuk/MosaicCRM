using Microsoft.Extensions.DependencyInjection;

namespace MosaicCRM.EntityFramework.DependencyInjection;

public interface IApplicationCommonDbContextRegistrationOptionsBuilder
{
    IServiceCollection Services { get; }
}