using Common.DDD;
using MediatR;

namespace PhotoManagementPlatform.Application.Abstractions.Messaging;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}
