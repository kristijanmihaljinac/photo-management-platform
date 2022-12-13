using FluentValidation;

namespace PhotoManagementPlatform.Application.Package.UseCases.GetPackageById
{
    public class GetPackageByIdUseCaseValidator : AbstractValidator<GetPackageByIdUseCase>
    {
        public GetPackageByIdUseCaseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(default(Guid));
        }
    }
}
