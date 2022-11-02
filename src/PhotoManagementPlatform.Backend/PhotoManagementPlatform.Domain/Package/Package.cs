using Common.DDD;

namespace PhotoManagementPlatform.Domain.Package;

public class Package : AggregateRoot
{
    public string Code { get; private set; }

    public string Name { get; private set; }
}
