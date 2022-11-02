using PhotoManagementPlatform.Application.Abstractions.Messaging;

namespace PhotoManagementPlatform.Application.Package.UseCases.CreatePackage;

public record CreatePackageUseCase(
    string Code, 
    string Name
    ) : IUseCase<Guid>;