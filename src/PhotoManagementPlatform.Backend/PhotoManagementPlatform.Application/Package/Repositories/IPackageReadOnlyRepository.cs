using Common.Specifications;
using PhotoManagementPlatform.Application.Package.UseCases.OverviewPackage;

namespace PhotoManagementPlatform.Application.Package.Repositories;

public interface IPackageReadOnlyRepository
{
    Task<Domain.Package.Package?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<OverviewPackageDto>> OverviewAsync(CancellationToken cancellationToken);

    Task<List<OverviewPackageDto>> OverviewBySpecification(OverviewSpecification<Domain.Package.Package> specification, CancellationToken cancellationToken);
}
