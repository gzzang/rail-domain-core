using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace RailDomainCore.Formations;

public class Formation : FullAuditedAggregateRoot<Guid>
{
    public Guid VersionId { get; private set; }
    public Guid TrainId { get; private set; }
    public string Code { get; private set; } = string.Empty;
    public short CoachCount { get; private set; }

    protected Formation()
    {
    }

    public Formation(Guid id, Guid versionId, Guid trainId, string code, short coachCount)
        : base(id)
    {
        SetComposition(versionId, trainId, code, coachCount);
    }

    public Formation SetComposition(Guid versionId, Guid trainId, string code, short coachCount)
    {
        VersionId = Check.NotNull(versionId, nameof(versionId));
        TrainId = Check.NotNull(trainId, nameof(trainId));
        Code = Check.NotNullOrWhiteSpace(code, nameof(code), maxLength: 64);
        CoachCount = Check.Range(coachCount, nameof(coachCount), (short)1, short.MaxValue);
        return this;
    }
}
