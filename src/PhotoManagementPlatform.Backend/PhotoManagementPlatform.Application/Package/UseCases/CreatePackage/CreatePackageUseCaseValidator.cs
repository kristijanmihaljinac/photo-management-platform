using FluentValidation;

namespace PhotoManagementPlatform.Application.Package.UseCases.CreatePackage;

internal sealed class CreatePackageUseCaseValidator : AbstractValidator<CreatePackageUseCase>
{
    public CreatePackageUseCaseValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(255);
    }
}
