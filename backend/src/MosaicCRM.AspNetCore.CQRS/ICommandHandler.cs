using MosaicCRM.AspNetCore.Responses;

namespace MosaicCRM.AspNetCore.CQRS;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : ICrmResponse
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}