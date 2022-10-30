using Common.DDD;

namespace PhotoManagementPlatform.Domain.Entities
{
    public class Package : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
    }
}
