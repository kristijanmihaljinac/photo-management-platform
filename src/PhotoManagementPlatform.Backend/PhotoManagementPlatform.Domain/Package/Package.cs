using Common.DDD;

namespace PhotoManagementPlatform.Domain.Package;

public class Package : AggregateRoot
{
    public string Code { get; private set; }

    public string Name { get; private set; }

    private Package(Guid id, string code, string name)
    {
        Id = id;
        Code = code;
        Name = name;
    }

    public static Package Create(
        Guid id,
        string code,
        string name
        )
    {
        Package package = new(id, code, name);
        return package;
    }
}
