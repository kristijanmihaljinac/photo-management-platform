using Microsoft.EntityFrameworkCore.Migrations;
using PhotoManagementPlatform.Persistence.Constants;

#nullable disable

namespace PhotoManagementPlatform.Persistence.Migrations
{
    public partial class PackageOverviewView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $"CREATE VIEW {nameof(PackageOverviewView)} " +
                "AS " +
                "SELECT " +
                "   Id, " +
                "   Code," +
                "   Name " +
                "FROM " +
                $"{TableNames.Packages} "
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $"DROP VIEW IF EXISTS {nameof(PackageOverviewView)} "
                );
        }
    }
}
