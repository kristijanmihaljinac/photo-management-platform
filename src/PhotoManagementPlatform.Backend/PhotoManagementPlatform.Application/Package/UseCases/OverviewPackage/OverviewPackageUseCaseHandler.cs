using Common.Shared;
using Common.SortingAndFiltering;
using Common.Specifications;
using PhotoManagementPlatform.Application.Abstractions.Messaging;
using PhotoManagementPlatform.Application.Package.Repositories;
using PhotoManagementPlatform.Application.Package.UseCases.DeletePackage;
using PhotoManagementPlatform.Domain.Repositories;

namespace PhotoManagementPlatform.Application.Package.UseCases.OverviewPackage;

public sealed class OverviewPackageUseCaseHandler : IUseCaseHandler<OverviewPackageUseCase, List<OverviewPackageDto>>
{

    private readonly IPackageReadOnlyRepository _packageReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    public OverviewPackageUseCaseHandler(
        IPackageReadOnlyRepository packageReadOnlyRepository, 
        IUnitOfWork unitOfWork)
    {
        _packageReadOnlyRepository= packageReadOnlyRepository;
        _unitOfWork= unitOfWork;
    }
    public async Task<Result<List<OverviewPackageDto>>> Handle(OverviewPackageUseCase request, CancellationToken cancellationToken)
    {
        /*var specification = new OverviewSpecificationBuilder<Domain.Package.Package>()
                            .WithFilter("Name", "Package 1")
                            .WithSort("DateCreated", SortDirection.Descending)
                            .Build();
        */

        var packages = await _packageReadOnlyRepository.OverviewAsync(cancellationToken);

        return Result.Success(packages);
    }
}
