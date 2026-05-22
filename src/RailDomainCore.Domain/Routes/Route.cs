using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace RailDomainCore.Routes;

public class Route : FullAuditedAggregateRoot<Guid>
{
    public Guid VersionId { get; private set; }
    public Guid TrainId { get; private set; }
    public Guid FormationId { get; private set; }
    public Guid OriginStationId { get; private set; }
    public Guid DestinationStationId { get; private set; }
    public string Code { get; private set; } = string.Empty;

    protected Route()
    {
    }

    public Route(Guid id, Guid versionId, Guid trainId, Guid formationId, Guid originStationId, Guid destinationStationId, string code)
        : base(id)
    {
        SetBinding(versionId, trainId, formationId, originStationId, destinationStationId, code);
    }

    public Route SetBinding(Guid versionId, Guid trainId, Guid formationId, Guid originStationId, Guid destinationStationId, string code)
    {
        VersionId = Check.NotNull(versionId, nameof(versionId));
        TrainId = Check.NotNull(trainId, nameof(trainId));
        FormationId = Check.NotNull(formationId, nameof(formationId));
        OriginStationId = Check.NotNull(originStationId, nameof(originStationId));
        DestinationStationId = Check.NotNull(destinationStationId, nameof(destinationStationId));
        Code = Check.NotNullOrWhiteSpace(code, nameof(code), maxLength: 64);

        if (OriginStationId == DestinationStationId)
        {
            throw new BusinessException("RailDomainCore:RouteTerminalConflict")
                .WithData("StationId", originStationId);
        }

        return this;
    }
}
