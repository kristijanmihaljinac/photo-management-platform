using Common.Mediator.Core;

namespace Common.Mediator.UseCases
{
    public interface IUseCaseHandler<in TUseCase, TResponse> : IMessageHandler<TUseCase, TResponse>
        where TUseCase : IMessage<TResponse>
    {

    }
}
