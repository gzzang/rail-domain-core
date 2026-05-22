using Volo.Abp.Domain.Repositories;

namespace RailDomainCore.Routes;

public interface IRouteRepository : IRepository<Route, Guid>
{
}
