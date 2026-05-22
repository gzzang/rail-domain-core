using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace RailDomainCore.Trains;

public class TrainStation : Entity<Guid>
{
    public Guid TrainId { get; private set; }
    public Guid StationId { get; private set; }
    public int Sequence { get; private set; }
    public TimeSpan? ArrivalOffset { get; private set; }
    public TimeSpan? DepartureOffset { get; private set; }

    protected TrainStation()
    {
    }

    public TrainStation(Guid id, Guid trainId, Guid stationId, int sequence, TimeSpan? arrivalOffset, TimeSpan? departureOffset)
        : base(id)
    {
        TrainId = Check.NotNull(trainId, nameof(trainId));
        StationId = Check.NotNull(stationId, nameof(stationId));
        MoveTo(sequence, arrivalOffset, departureOffset);
    }

    public TrainStation MoveTo(int sequence, TimeSpan? arrivalOffset, TimeSpan? departureOffset)
    {
        Sequence = Check.Range(sequence, nameof(sequence), 1, int.MaxValue);
        ArrivalOffset = arrivalOffset;
        DepartureOffset = departureOffset;
        return this;
    }
}
