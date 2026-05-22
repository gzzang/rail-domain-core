using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace RailDomainCore.Versions;

public class Version : FullAuditedAggregateRoot<Guid>
{
    public string Code { get; private set; } = string.Empty;
    public DateOnly EffectiveDate { get; private set; }
    public string? Description { get; private set; }

    protected Version()
    {
    }

    public Version(Guid id, string code, DateOnly effectiveDate, string? description = null)
        : base(id)
    {
        SetIdentity(code, effectiveDate, description);
    }

    public Version SetIdentity(string code, DateOnly effectiveDate, string? description = null)
    {
        Code = Check.NotNullOrWhiteSpace(code, nameof(code), maxLength: 64);
        EffectiveDate = effectiveDate;
        Description = Check.Length(description, nameof(description), maxLength: 512);
        return this;
    }
}
