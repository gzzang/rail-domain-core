using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailDomainCore.Formations;
using RailDomainCore.Routes;
using RailDomainCore.Stations;
using RailDomainCore.Trains;
using VersionAggregate = RailDomainCore.Versions.Version;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace RailDomainCore.EntityFrameworkCore;

public static class RailDomainCoreModelBuilderExtensions
{
    public static void ConfigureRailDomainCore(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Station>(ConfigureStation);
        builder.Entity<VersionAggregate>(ConfigureVersion);
        builder.Entity<Train>(ConfigureTrain);
        builder.Entity<TrainStation>(ConfigureTrainStation);
        builder.Entity<Formation>(ConfigureFormation);
        builder.Entity<Route>(ConfigureRoute);
    }

    private static void ConfigureStation(EntityTypeBuilder<Station> builder)
    {
        builder.ToTable($"{RailDomainCoreConsts.DbTablePrefix}Stations", RailDomainCoreConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        builder.HasIndex(x => x.Code).IsUnique();
    }

    private static void ConfigureVersion(EntityTypeBuilder<VersionAggregate> builder)
    {
        builder.ToTable($"{RailDomainCoreConsts.DbTablePrefix}Versions", RailDomainCoreConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(64);
        builder.Property(x => x.EffectiveDate).HasColumnType("date");
        builder.Property(x => x.Description).HasMaxLength(512);
        builder.HasIndex(x => x.Code).IsUnique();
    }

    private static void ConfigureTrain(EntityTypeBuilder<Train> builder)
    {
        builder.ToTable($"{RailDomainCoreConsts.DbTablePrefix}Trains", RailDomainCoreConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Number).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        builder.HasIndex(x => new { x.VersionId, x.Number }).IsUnique();
        builder.Navigation("_stations").UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.HasMany<TrainStation>("_stations")
            .WithOne()
            .HasForeignKey(x => x.TrainId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void ConfigureTrainStation(EntityTypeBuilder<TrainStation> builder)
    {
        builder.ToTable($"{RailDomainCoreConsts.DbTablePrefix}TrainStations", RailDomainCoreConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Sequence).IsRequired();
        builder.HasIndex(x => new { x.TrainId, x.Sequence }).IsUnique();
    }

    private static void ConfigureFormation(EntityTypeBuilder<Formation> builder)
    {
        builder.ToTable($"{RailDomainCoreConsts.DbTablePrefix}Formations", RailDomainCoreConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(64);
        builder.HasIndex(x => new { x.TrainId, x.Code }).IsUnique();
    }

    private static void ConfigureRoute(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable($"{RailDomainCoreConsts.DbTablePrefix}Routes", RailDomainCoreConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(64);
        builder.HasIndex(x => new { x.TrainId, x.FormationId, x.Code }).IsUnique();
    }
}
