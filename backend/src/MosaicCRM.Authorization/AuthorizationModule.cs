using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MosaicCRM.Authorization.Abstractions;
using MosaicCRM.Authorization.Abstractions.Permissions;
using MosaicCRM.Authorization.Permissions;
using MosaicCRM.Core.Extensions.Collections;
using MosaicCRM.Core.Extensions.DependencyInjection;
using MosaicCRM.Core.Modularity;
using MosaicCRM.Security;

namespace MosaicCRM.Authorization;

[DependsOn(typeof(SecurityModule),typeof(AuthorizationAbstractionModule))]
public partial class AuthorizationModule : CrmModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.OnRegistered(AuthorizationInterceptorRegistrar.RegisterIfNeeded);
        AutoAddDefinitionProviders(context.Services);
    }


    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        
        context.Services.AddAuthorizationCore();

        context.Services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
        context.Services.AddSingleton<IAuthorizationHandler, PermissionsRequirementHandler>();

        context.Services.TryAddTransient<DefaultAuthorizationPolicyProvider>();

        Configure<CrmPermissionOptions>(options =>
        {
            options.ValueProviders.Add<UserPermissionValueProvider>();
            options.ValueProviders.Add<RolePermissionValueProvider>();
            options.ValueProviders.Add<ClientPermissionValueProvider>();
        });
    }

    private static void AutoAddDefinitionProviders(IServiceCollection services)
    {
        var definitionProviders = new List<Type>();

        services.OnRegistered(context =>
        {
            if (typeof(IPermissionDefinitionProvider).IsAssignableFrom(context.ImplementationType))
            {
                definitionProviders.Add(context.ImplementationType);
            }
        });

        services.Configure<CrmPermissionOptions>(options =>
        {
            options.DefinitionProviders.AddIfNotContains(definitionProviders);
        });
    }
}