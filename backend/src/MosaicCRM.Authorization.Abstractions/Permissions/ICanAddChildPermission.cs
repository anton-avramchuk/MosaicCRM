namespace MosaicCRM.Authorization.Abstractions.Permissions;

public interface ICanAddChildPermission
{
    PermissionDefinition AddPermission(
        string name,
        string displayName,
        bool isEnabled = true);
}