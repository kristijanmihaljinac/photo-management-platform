using Common.Mediator.Core;

namespace Common.Mediator.Events
{
    public interface IEventHandler<in TEvent> : IMessageHandler<TEvent, Unit> where TEvent : IMessage<Unit>
    {
    }
}
