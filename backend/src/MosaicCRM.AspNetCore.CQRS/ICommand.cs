using MosaicCRM.AspNetCore.Responses;

namespace MosaicCRM.AspNetCore.CQRS;

public interface ICommand<out TResponse> where TResponse:ICrmResponse
{
    
}