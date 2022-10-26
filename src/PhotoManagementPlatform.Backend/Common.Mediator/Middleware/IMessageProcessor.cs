using Common.Mediator.Core;

namespace Common.Mediator.Middleware
{
    public interface IMessageProcessor<in TMessage, TResponse>
        where TMessage : IMessage<TResponse>
    {
        Task<TResponse> HandleAsync(TMessage message, IMediationContext mediationContext,
            CancellationToken cancellationToken);
    }
}
