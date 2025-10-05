using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Authorization.Abstractions.Permissions;

[Export(LifetimeType.Transient, typeof(IPermissionValueProvider))]
public abstract class PermissionDefinitionProvider : IPermissionDefinitionProvider
{
    public virtual void PreDefine(IPermissionDefinitionContext context)
    {
    }

    public abstract void Define(IPermissionDefinitionContext context);

    public virtual void PostDefine(IPermissionDefinitionContext context)
    {
    }
}