using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoManagementPlatform.Persistence.Constants;
using PhotoManagementPlatform.Persistence.Outbox;

namespace PhotoManagementPlatform.Persistence.Configurations;

internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable(TableNames.OutboxMessages);

        builder.Property(x => x.EntityType)
            .IsRequired(true)
            .HasMaxLength(255);

        builder.HasKey(x => x.Id);
    }
}
