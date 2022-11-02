using PhotoManagementPlatform.Application.Abstractions.Messaging;

namespace PhotoManagementPlatform.Application.Package.UseCases.UpdatePackage;

public record UpdatePackageUseCase(Guid Id, string Code, string Name)
    : IUseCase;
