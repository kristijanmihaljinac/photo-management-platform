using Common.Application;
using MediatR;

namespace Common.DDD
{
    public interface IDomainEvent : INotification
    {
        public Guid EntityId { get; set; }
        public EntityType EntityType { get; set; }
    }
}

