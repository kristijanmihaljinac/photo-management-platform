using Common.Mediator.Core;

namespace Common.Mediator.UseCases
{
    public interface IUseCase<TResult> : IMessage<TResult>
    {
    }
}
