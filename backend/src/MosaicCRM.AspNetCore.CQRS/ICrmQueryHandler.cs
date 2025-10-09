using MosaicCRM.AspNetCore.Responses;

namespace MosaicCRM.AspNetCore.CQRS;

public interface ICrmQueryHandler<in TQuery, TResponse>
    where TQuery : ICrmQuery<TResponse>
    where TResponse : ICrmResponse
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}