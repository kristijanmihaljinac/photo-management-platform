
using PhotoManagementPlatform.Application.Package.Repositories;
using PhotoManagementPlatform.Persistence;

namespace PhotoManagementPlatform.Infrastructure.Repositories.Package;

public class PackageWriteOnlyRepository : IPackageWriteOnlyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PackageWriteOnlyRepository(ApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(Domain.Package.Package package) =>
        _dbContext.Set<Domain.Package.Package>().Add(package);

    public void Update(Domain.Package.Package package) =>
        _dbContext.Set<Domain.Package.Package>().Update(package);

    public void Remove(Domain.Package.Package package) =>
        _dbContext.Set<Domain.Package.Package>().Update(package);
}

