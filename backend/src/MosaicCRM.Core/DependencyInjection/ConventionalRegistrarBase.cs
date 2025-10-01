using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MosaicCRM.Core.Extensions.Common;
using MosaicCRM.Core.Extensions.DependencyInjection;
using MosaicCRM.Core.Reflection;

namespace MosaicCRM.Core.DependencyInjection;

public abstract class ConventionalRegistrarBase : IConventionalRegistrar
{
    public virtual void AddAssembly(IServiceCollection services, Assembly assembly)
    {
        var types = AssemblyHelper
            .GetAllTypes(assembly)
            .Where(
                type => type is { IsClass: true, IsAbstract: false, IsGenericType: false }
            ).ToArray();

        AddTypes(services, types);
    }

    public virtual void AddTypes(IServiceCollection services, params Type[] types)
    {
        foreach (var type in types)
        {
            AddType(services, type);
        }
    }

    public abstract void AddType(IServiceCollection services, Type type);

    protected virtual bool IsConventionalRegistrationDisabled(Type type)
    {
        return type.IsDefined(typeof(DisableConventionalRegistrationAttribute), true);
    }

    protected virtual void TriggerServiceExposing(IServiceCollection services, Type implementationType, List<Type> serviceTypes)
    {
        var exposeActions = services.GetExposingActionList();
        if (exposeActions.Any())
        {
            var args = new OnServiceExposingContext(implementationType, serviceTypes);
            foreach (var action in exposeActions)
            {
                action(args);
            }
        }
    }

    protected virtual DependencyAttribute? GetDependencyAttributeOrNull(Type type)
    {
        return type.GetCustomAttribute<DependencyAttribute>(true);
    }

    protected virtual ServiceLifetime? GetLifeTimeOrNull(Type type, DependencyAttribute? dependencyAttribute)
    {
        return dependencyAttribute?.Lifetime ?? GetServiceLifetimeFromClassHierarchy(type) ?? GetDefaultLifeTimeOrNull(type);
    }

    protected virtual ServiceLifetime? GetServiceLifetimeFromClassHierarchy(Type type)
    {
        var exportAttribute = type.GetCustomAttribute<ExportAttribute>();

        if (exportAttribute == null)
            return null;

        switch (exportAttribute.Lifetime)
        {
            case LifetimeType.Transient:
                return ServiceLifetime.Transient;
            case LifetimeType.Singleton:
                return ServiceLifetime.Singleton;
            case LifetimeType.Scoped:
                return ServiceLifetime.Scoped;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected virtual ServiceLifetime? GetDefaultLifeTimeOrNull(Type type)
    {
        return null;
    }


    protected virtual ServiceDescriptor CreateServiceDescriptor(
        Type implementationType,
        Type exposingServiceType,
        List<Type> allExposingServiceTypes,
        ServiceLifetime lifeTime)
    {
        if (lifeTime.IsIn(ServiceLifetime.Singleton, ServiceLifetime.Scoped))
        {
            var redirectedType = GetRedirectedTypeOrNull(
                implementationType,
                exposingServiceType,
                allExposingServiceTypes
            );

            if (redirectedType != null)
            {
                return ServiceDescriptor.Describe(
                    exposingServiceType,
                    provider => provider.GetService(redirectedType)!,
                    lifeTime
                );
            }
        }

        return ServiceDescriptor.Describe(
            exposingServiceType,
            implementationType,
            lifeTime
        );
    }

    protected virtual Type? GetRedirectedTypeOrNull(
        Type implementationType,
        Type exposingServiceType,
        List<Type> allExposingServiceTypes)
    {
        if (allExposingServiceTypes.Count < 2)
        {
            return null;
        }

        if (exposingServiceType == implementationType)
        {
            return null;
        }

        if (allExposingServiceTypes.Contains(implementationType))
        {
            return implementationType;
        }

        return allExposingServiceTypes.FirstOrDefault(
            t => t != exposingServiceType && exposingServiceType.IsAssignableFrom(t)
        );
    }

}