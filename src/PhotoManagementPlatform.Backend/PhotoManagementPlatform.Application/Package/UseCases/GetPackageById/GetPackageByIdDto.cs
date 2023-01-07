using System;
namespace PhotoManagementPlatform.Application.Package.UseCases.GetPackageById
{
	public record GetPackageByIdDto(
		Guid Id,
		string Code,
		string Name
		);
}

