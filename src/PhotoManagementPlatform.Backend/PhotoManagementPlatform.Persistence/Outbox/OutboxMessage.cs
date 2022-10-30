using System;
using PhotoManagementPlatform.Domain.Constants;
using PhotoManagementPlatform.Domain.Enum;
namespace PhotoManagementPlatform.Persistence.Outbox;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }

    public Guid? EntityId { get; set; }

    public string? EntityType { get; set; }

    public string DeliveryState { get; set; } = DeliveryStates.InProgress;

    public string EventType { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ProcessedOnUtc { get; set; }

    public string? Note { get; set; }
    
}

