namespace MosaicCRM.AspNetCore.CQRS;

public class CommandApiDescriptionAttribute(
    string route,
    ApiMethodType type,
    string? description = null,
    bool apiPrefix = true,
    params string[]? tags) : ApiDescriptionAttribute(route, type, description, apiPrefix, tags);