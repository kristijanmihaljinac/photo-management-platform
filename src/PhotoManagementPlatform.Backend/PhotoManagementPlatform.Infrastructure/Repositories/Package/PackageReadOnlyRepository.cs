using PhotoManagementPlatform.Application.Package.Repositories;
using PhotoManagementPlatform.Persistence;
using Microsoft.EntityFrameworkCore;
using PhotoManagementPlatform.Application.Package.UseCases.OverviewPackage;
using Common.Specifications;
using PhotoManagementPlatform.Infrastructure.Specifications;

namespace PhotoManagementPlatform.Infrastructure.Repositories.Package;

public class PackageReadOnlyRepository : IPackageReadOnlyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PackageReadOnlyRepository(ApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<bool> ExistsWithCodeAsync(string code, CancellationToken cancellationToken) =>
       await _dbContext.Set<Domain.Package.Package>().AnyAsync(x => x.Code == code, cancellationToken);
    

    public async Task<Domain.Package.Package?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbContext.Set<Domain.Package.Package>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);


    public async Task<List<OverviewPackageDto>> OverviewAsync(CancellationToken cancellationToken) =>
        await _dbContext.Set<Domain.Package.Package>().Select(x => new OverviewPackageDto(x.Id, x.Code, x.Name)).ToListAsync(cancellationToken);

    public async Task<List<OverviewPackageDto>> OverviewBySpecification(OverviewSpecification<Domain.Package.Package> specification, CancellationToken cancellationToken)
    {
        var result = await SpecificationEvaluator.GetQuery(
           _dbContext.Set<Domain.Package.Package>(),
                specification).Select(package => 
                   new OverviewPackageDto(
                       package.Id, 
                       package.Code, 
                       package.Name))
           .ToListAsync();

        return result;
    }
}