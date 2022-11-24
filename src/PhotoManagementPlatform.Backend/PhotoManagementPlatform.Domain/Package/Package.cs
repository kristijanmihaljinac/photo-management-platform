using Common.DDD;

namespace PhotoManagementPlatform.Domain.Package;

public class Package : AggregateRoot, IAuditableEntity
{
    public string Code { get; private set; }

    public string Name { get; private set; }

    #region Auditable
    public DateTime CreatedOnUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public string? ModifiedBy { get; set; }
    public bool Active { get; set; } = true;
    #endregion


    private Package(Guid id, string code, string name)
    {
        Id = id;
        Code = code;
        Name = name;
        Active = true;
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

    public void Update(
        string code,
        string name
        )
    {
        Code = code;
        Name = name;
    }

    public void Remove()
    {
        Active = false;
    }
}
