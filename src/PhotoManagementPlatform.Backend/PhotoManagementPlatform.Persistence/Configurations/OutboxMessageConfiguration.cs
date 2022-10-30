using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoManagementPlatform.Domain.Constants;
using PhotoManagementPlatform.Persistence.Constants;
using PhotoManagementPlatform.Persistence.Outbox;

namespace PhotoManagementPlatform.Persistence.Configurations;

internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable(TableNames.OutboxMessages);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EntityId)
            .IsRequired(false);

        builder.Property(x => x.EntityType)
            .HasColumnType("nvarchar")
            .IsRequired(false)
            .HasMaxLength(255);

        builder.Property(x => x.DeliveryState)
            .HasColumnType("nvarchar")
            .IsRequired(true)
            .HasDefaultValue(DeliveryStates.InProgress)
            .HasMaxLength(255);

        builder.Property(x => x.EventType)
            .HasColumnType("nvarchar")
            .IsRequired(true)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(500);

        builder.Property(x => x.Content)
            .HasColumnType("nvarchar(max)")
            .IsRequired(true);


        builder.Property(x => x.CreatedOnUtc)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");


        builder.Property(x => x.ProcessedOnUtc)
            .IsRequired(false);

        builder.Property(x => x.Note)
            .HasMaxLength(500)
            .IsRequired(false);
    }
}
