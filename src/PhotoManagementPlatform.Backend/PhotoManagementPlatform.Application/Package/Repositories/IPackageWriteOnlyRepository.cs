namespace PhotoManagementPlatform.Application.Package.Repositories;

public interface IPackageWriteOnlyRepository
{
    void Add(Domain.Package.Package package);

    void Update(Domain.Package.Package package);

    void Remove(Domain.Package.Package package);
}
