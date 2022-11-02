using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoManagementPlatform.Persistence.Constants;

namespace PhotoManagementPlatform.Persistence.Configurations.Package;

internal sealed class PackageConfiguration : IEntityTypeConfiguration<Domain.Package.Package>
{
    public void Configure(EntityTypeBuilder<Domain.Package.Package> builder)
    {
        builder.ToTable(TableNames.Packages);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
           .IsRequired(true)
           .HasColumnType("nvarchar")
           .HasMaxLength(50);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("nvarchar")
            .HasMaxLength(255);

        builder.Property(x => x.CreatedOnUtc)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired(true);

        builder.Property(x => x.CreatedBy)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.Property(x => x.ModifiedOnUtc)
            .IsRequired(false);

        builder.Property(x => x.ModifiedBy)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.Property(x => x.Active)
            .IsRequired(true)
            .HasDefaultValue(true);

    }
}
