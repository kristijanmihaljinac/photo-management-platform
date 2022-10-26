namespace Common.Mediator.Core
{
    public interface IMediator
    {
        Task<TResponse> HandleAsync<TResponse>(IMessage<TResponse> message, IMediationContext mediationContext = default,
          CancellationToken cancellationToken = default);
    }
}
