namespace MosaicCRM.AspNetCore.CQRS;

public sealed class QueryApiDescriptionAttribute(
    string route,
    string? description = null,
    bool apiPrefix = true,
    params string[]? tags)
    : ApiDescriptionAttribute(route, ApiMethodType.Get, description, apiPrefix, tags);