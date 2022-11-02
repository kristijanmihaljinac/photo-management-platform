using Common.Shared;
using PhotoManagementPlatform.Application.Abstractions.Messaging;

namespace PhotoManagementPlatform.Application.Package.UseCases.CreatePackage;

internal sealed class CreatePackageUseCaseHandler : IUseCaseHandler<CreatePackageUseCase, Result<Guid>>
{
    public async Task<Result<Result<Guid>>> Handle(CreatePackageUseCase request, CancellationToken cancellationToken)
    {
        var package = Domain.Package.Package.Create(
            Guid.NewGuid(),
            request.Code,
            request.Name
            );

    }
}
