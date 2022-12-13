using Common.Shared;
using PhotoManagementPlatform.Application.Abstractions.Messaging;
using PhotoManagementPlatform.Application.Package.Repositories;
using PhotoManagementPlatform.Domain.Repositories;

namespace PhotoManagementPlatform.Application.Package.UseCases.UpdatePackage;

internal class UpdatePackageUseCaseHandler : IUseCaseHandler<UpdatePackageUseCase>
{
    private readonly IPackageWriteOnlyRepository _packageWriteOnlyRepository;
    private readonly IPackageReadOnlyRepository _packageReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePackageUseCaseHandler(
        IPackageWriteOnlyRepository packageWriteOnlyRepository,
        IPackageReadOnlyRepository packageReadOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _packageWriteOnlyRepository = packageWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _packageReadOnlyRepository = packageReadOnlyRepository;
    }

    public async Task<Result> Handle(UpdatePackageUseCase request, CancellationToken cancellationToken)
    {
        Domain.Package.Package? package = await _packageReadOnlyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (package is null)
        {
            return Result.Failure(Error.NotFound);
        }

        package.Update(
            request.Code,
            request.Name
            );

        _packageWriteOnlyRepository.Update(package);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}