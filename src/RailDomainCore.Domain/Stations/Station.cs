using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace RailDomainCore.Stations;

public class Station : Entity<Guid>
{
    public string Code { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;

    protected Station()
    {
    }

    public Station(Guid id, string code, string name)
        : base(id)
    {
        SetIdentity(code, name);
    }

    public Station SetIdentity(string code, string name)
    {
        Code = Check.NotNullOrWhiteSpace(code, nameof(code), maxLength: 32);
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: 128);
        return this;
    }
}
