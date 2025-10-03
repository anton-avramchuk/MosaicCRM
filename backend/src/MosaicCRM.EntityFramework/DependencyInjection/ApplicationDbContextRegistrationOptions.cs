using Microsoft.Extensions.DependencyInjection;

namespace MosaicCRM.EntityFramework.DependencyInjection;

public class ApplicationDbContextRegistrationOptions : ApplicationCommonDbContextRegistrationOptions, IApplicationCommonDbContextRegistrationOptionsBuilder
{


    public ApplicationDbContextRegistrationOptions(Type originalDbContextType, IServiceCollection services) : base(originalDbContextType, services)
    {
    }



}