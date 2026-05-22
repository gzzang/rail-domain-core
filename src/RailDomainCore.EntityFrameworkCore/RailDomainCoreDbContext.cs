using Microsoft.EntityFrameworkCore;
using RailDomainCore.Formations;
using RailDomainCore.Routes;
using RailDomainCore.Stations;
using RailDomainCore.Trains;
using VersionAggregate = RailDomainCore.Versions.Version;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RailDomainCore.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class RailDomainCoreDbContext : AbpDbContext<RailDomainCoreDbContext>
{
    public DbSet<Station> Stations => Set<Station>();
    public DbSet<VersionAggregate> Versions => Set<VersionAggregate>();
    public DbSet<Train> Trains => Set<Train>();
    public DbSet<TrainStation> TrainStations => Set<TrainStation>();
    public DbSet<Formation> Formations => Set<Formation>();
    public DbSet<Route> Routes => Set<Route>();

    public RailDomainCoreDbContext(DbContextOptions<RailDomainCoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureRailDomainCore();
    }
}
