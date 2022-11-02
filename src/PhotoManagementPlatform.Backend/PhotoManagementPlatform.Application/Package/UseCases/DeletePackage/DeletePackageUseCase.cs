using PhotoManagementPlatform.Application.Abstractions.Messaging;

namespace PhotoManagementPlatform.Application.Package.UseCases.DeletePackage;

public record DeletePackageUseCase(
    Guid Id
    ) : IUseCase;
