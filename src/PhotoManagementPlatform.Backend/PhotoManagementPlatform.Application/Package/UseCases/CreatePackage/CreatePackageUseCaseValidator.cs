using FluentValidation;
using PhotoManagementPlatform.Application.Package.Repositories;

namespace PhotoManagementPlatform.Application.Package.UseCases.CreatePackage;

internal sealed class CreatePackageUseCaseValidator : AbstractValidator<CreatePackageUseCase>
{
    private readonly IPackageReadOnlyRepository _packageReadOnlyRepository;
    public CreatePackageUseCaseValidator(IPackageReadOnlyRepository packageReadOnlyRepository)
    {
        _packageReadOnlyRepository = packageReadOnlyRepository;

        CreateRules();
    }

    private void CreateRules()
    {
        RuleFor(x => x.Code)
              .NotEmpty()
              .MaximumLength(50).WithMessage("Maximum Length is 50!")
              .MustAsync(async (code, cancellationToken) => 
                          !await _packageReadOnlyRepository.ExistsWithCodeAsync(code, cancellationToken)).WithMessage("Code must bew unique!");


        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(255);
    }
}
