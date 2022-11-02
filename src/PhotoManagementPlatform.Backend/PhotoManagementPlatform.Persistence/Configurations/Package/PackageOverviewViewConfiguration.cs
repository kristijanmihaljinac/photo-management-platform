using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoManagementPlatform.Persistence.Views;

namespace PhotoManagementPlatform.Persistence.Configurations.Package;

internal sealed class PackageOverviewViewConfiguration : IEntityTypeConfiguration<PackageOverviewView>
{
    public void Configure(EntityTypeBuilder<PackageOverviewView> builder)
    {
        builder
           .ToView(nameof(PackageOverviewView));

        builder
            .HasKey(x => x.Id);

    }
}
