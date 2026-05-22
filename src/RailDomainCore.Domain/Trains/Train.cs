using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace RailDomainCore.Trains;

public class Train : FullAuditedAggregateRoot<Guid>
{
    private readonly List<TrainStation> _stations = [];

    public Guid VersionId { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public IReadOnlyList<TrainStation> Stations => _stations.OrderBy(x => x.Sequence).ToList();

    protected Train()
    {
    }

    public Train(Guid id, Guid versionId, string number, string name)
        : base(id)
    {
        SetIdentity(versionId, number, name);
    }

    public Train SetIdentity(Guid versionId, string number, string name)
    {
        VersionId = Check.NotNull(versionId, nameof(versionId));
        Number = Check.NotNullOrWhiteSpace(number, nameof(number), maxLength: 32);
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: 128);
        return this;
    }

    public TrainStation AddStation(Guid stationId, int sequence, TimeSpan? arrivalOffset, TimeSpan? departureOffset)
    {
        Check.NotNull(stationId, nameof(stationId));
        Check.Range(sequence, nameof(sequence), 1, int.MaxValue);

        if (_stations.Any(x => x.Sequence == sequence))
        {
            throw new BusinessException("RailDomainCore:DuplicateTrainStationSequence")
                .WithData("TrainId", Id)
                .WithData("Sequence", sequence);
        }

        var trainStation = new TrainStation(Guid.NewGuid(), Id, stationId, sequence, arrivalOffset, departureOffset);
        _stations.Add(trainStation);
        return trainStation;
    }
}
