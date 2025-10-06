using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.AspNetCore.Jwt.Services;
using MosaicCRM.Modules.Identity.AspNetCore.Jwt.Services;
using MosaicCRM.Modules.Identity.Domain;

namespace MosaicCRM.Modules.Identity.AspNetCore.Jwt.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityJwtAuth<TIdentityDbContext,TIdentityUser,TIdentityRole>(this IServiceCollection services)
    where TIdentityDbContext: IdentityDbContext<TIdentityDbContext, TIdentityUser, TIdentityRole>
    where TIdentityUser : CrmIdentityUser<TIdentityRole>
    where TIdentityRole : CrmIdentityRole
    {
        services.AddScoped<ILoginService<LoginModel>, IdentityLoginService<TIdentityUser,TIdentityRole>>();
        //services.AddIdentity<>()
        return services;
    }
}