using PhotoManagementPlatform.Application.Abstractions.Messaging;
using PhotoManagementPlatform.Application.Package.Repositories;

namespace PhotoManagementPlatform.Application.Package.UseCases.CreatePackage;

internal sealed class CreatePackageUseCaseHandler : IUseCaseHandler<CreatePackageUseCase, Guid>
{
    private readonly IPackageWriteOnlyRepository _packageWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePackageUseCaseHandler(
        IPackageWriteOnlyRepository packageWriteOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _packageWriteOnlyRepository = packageWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreatePackageUseCase request, CancellationToken cancellationToken)
    {
        var package = Domain.Package.Package.Create(
                                                Guid.NewGuid(),
                                                request.Code,
                                                request.Name
                                                );


        _packageWriteOnlyRepository.Add(package);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(package.Id);
    }

}
