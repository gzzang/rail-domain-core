using Volo.Abp.Domain.Repositories;

namespace RailDomainCore.Versions;

public interface IVersionRepository : IRepository<Version, Guid>
{
}
