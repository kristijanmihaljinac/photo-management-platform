using Common.Mediator.Core;

namespace Common.Mediator.UseCases
{
    public abstract class UseCaseHandler<TUseCase, TResponse> : IUseCaseHandler<TUseCase, TResponse> where TUseCase : IMessage<TResponse>
    {
        public Task<TResponse> HandleAsync(TUseCase message, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            return HandleUseCaseAsync(message, mediationContext, cancellationToken);
        }

        protected abstract Task<TResponse> HandleUseCaseAsync(TUseCase useCase, IMediationContext mediationContext,
          CancellationToken cancellationToken);
    }
}
