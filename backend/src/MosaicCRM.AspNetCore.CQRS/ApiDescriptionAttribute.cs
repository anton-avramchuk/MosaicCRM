namespace MosaicCRM.AspNetCore.CQRS;

public abstract class ApiDescriptionAttribute(
    string route,
    ApiMethodType type,
    string? description = null,
    bool apiPrefix = true,
    params string[]? tags)
    : Attribute
{
    public string Route { get; } = route;

    public string? Description { get; } = description;

    public string[]? Tags { get; } = tags;

    public bool ApiPrefix { get; } = apiPrefix;

    public ApiMethodType Type { get; } = type;
}