using Volo.Abp.Domain.Repositories;

namespace RailDomainCore.Stations;

public interface IStationRepository : IRepository<Station, Guid>
{
}
