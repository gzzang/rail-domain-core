using Volo.Abp.Domain.Repositories;

namespace RailDomainCore.Trains;

public interface ITrainRepository : IRepository<Train, Guid>
{
}
