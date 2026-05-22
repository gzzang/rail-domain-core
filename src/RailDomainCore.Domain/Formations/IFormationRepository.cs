using Volo.Abp.Domain.Repositories;

namespace RailDomainCore.Formations;

public interface IFormationRepository : IRepository<Formation, Guid>
{
}
