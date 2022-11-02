using Common.Shared;
using PhotoManagementPlatform.Application.Abstractions.Messaging;
using PhotoManagementPlatform.Application.Package.Repositories;
using PhotoManagementPlatform.Domain.Repositories;

namespace PhotoManagementPlatform.Application.Package.UseCases.DeletePackage;

public sealed class DeletePackageUseCaseHandler : IUseCaseHandler<DeletePackageUseCase>
{
    private readonly IPackageWriteOnlyRepository _packageWriteOnlyRepository;
    private readonly IPackageReadOnlyRepository _packageReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePackageUseCaseHandler(
        IPackageWriteOnlyRepository packageWriteOnlyRepository,
        IPackageReadOnlyRepository packageReadOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _packageReadOnlyRepository = packageReadOnlyRepository;
        _packageWriteOnlyRepository = packageWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePackageUseCase request, CancellationToken cancellationToken)
    {
        Domain.Package.Package? package = await _packageReadOnlyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (package is null)
        {
            return Result.Failure(new Error("404", "NotFound"));
        }

        package.Remove();

        _packageWriteOnlyRepository.Remove(package);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
