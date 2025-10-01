using System;

namespace MosaicCRM.Core.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ExportAttribute : Attribute
{
    public ExportAttribute(LifetimeType lifetime, params Type[] types)
    {
        Lifetime = lifetime;
        Types = types;
    }

    public LifetimeType Lifetime { get; set; }
    public Type[] Types { get; }
}