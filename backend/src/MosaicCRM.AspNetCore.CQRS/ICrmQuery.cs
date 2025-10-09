using MosaicCRM.AspNetCore.Responses;

namespace MosaicCRM.AspNetCore.CQRS;

public interface ICrmQuery<out TResponse> where TResponse:ICrmResponse
{
    
}