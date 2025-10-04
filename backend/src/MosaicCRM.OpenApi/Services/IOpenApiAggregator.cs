using Microsoft.OpenApi.Models;

namespace MosaicCRM.OpenApi.Services;

public interface IOpenApiAggregator
{
    Task<OpenApiDocument> GetCombinedOpenApiDocumentAsync();
}