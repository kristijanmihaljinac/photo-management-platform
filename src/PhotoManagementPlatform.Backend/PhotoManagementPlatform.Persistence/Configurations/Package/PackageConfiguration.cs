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
    }
}
