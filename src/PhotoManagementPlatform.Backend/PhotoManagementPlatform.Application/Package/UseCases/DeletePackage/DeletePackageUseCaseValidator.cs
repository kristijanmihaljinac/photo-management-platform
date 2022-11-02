
using FluentValidation;

namespace PhotoManagementPlatform.Application.Package.UseCases.DeletePackage;

public class DeletePackageUseCaseValidator : AbstractValidator<DeletePackageUseCase>
{
    public DeletePackageUseCaseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(default(Guid));
    }
}

