using RailDomainCore.Formations;
using RailDomainCore.Routes;
using RailDomainCore.Trains;
using Volo.Abp;

namespace RailDomainCore.Domain.Tests;

public class DomainModelTests
{
    [Fact]
    public void Train_should_reject_duplicate_station_sequence()
    {
        var train = new Train(Guid.NewGuid(), Guid.NewGuid(), "G1001", "京沪测试列车");

        train.AddStation(Guid.NewGuid(), 1, TimeSpan.Zero, TimeSpan.FromMinutes(2));

        var exception = Assert.Throws<BusinessException>(() =>
            train.AddStation(Guid.NewGuid(), 1, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(32)));

        Assert.Equal("RailDomainCore:DuplicateTrainStationSequence", exception.Code);
    }

    [Fact]
    public void Formation_and_route_should_keep_requested_aggregate_bindings()
    {
        var versionId = Guid.NewGuid();
        var trainId = Guid.NewGuid();
        var formation = new Formation(Guid.NewGuid(), versionId, trainId, "CR400AF-16", 16);
        var route = new Route(
            Guid.NewGuid(),
            versionId,
            trainId,
            formation.Id,
            Guid.NewGuid(),
            Guid.NewGuid(),
            "京沪主线");

        Assert.Equal(versionId, formation.VersionId);
        Assert.Equal(trainId, formation.TrainId);
        Assert.Equal(versionId, route.VersionId);
        Assert.Equal(trainId, route.TrainId);
        Assert.Equal(formation.Id, route.FormationId);
    }

    [Fact]
    public void Route_should_require_distinct_terminal_stations()
    {
        var stationId = Guid.NewGuid();

        var exception = Assert.Throws<BusinessException>(() =>
            new Route(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), stationId, stationId, "回环线"));

        Assert.Equal("RailDomainCore:RouteTerminalConflict", exception.Code);
    }
}
