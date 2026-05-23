using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailDomainCore.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RailFormations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CoachCount = table.Column<short>(type: "smallint", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailFormations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormationId = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginStationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DestinationStationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailTrains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VersionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailTrains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    EffectiveDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RailTrainStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainId = table.Column<Guid>(type: "uuid", nullable: false),
                    StationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    ArrivalOffset = table.Column<TimeSpan>(type: "interval", nullable: true),
                    DepartureOffset = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailTrainStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RailTrainStations_RailTrains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "RailTrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RailFormations_TrainId_Code",
                table: "RailFormations",
                columns: new[] { "TrainId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RailRoutes_TrainId_FormationId_Code",
                table: "RailRoutes",
                columns: new[] { "TrainId", "FormationId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RailStations_Code",
                table: "RailStations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RailTrains_VersionId_Number",
                table: "RailTrains",
                columns: new[] { "VersionId", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RailTrainStations_TrainId_Sequence",
                table: "RailTrainStations",
                columns: new[] { "TrainId", "Sequence" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RailVersions_Code",
                table: "RailVersions",
                column: "Code",
                unique: true);

            SeedData(migrationBuilder);
        }

        private static void SeedData(MigrationBuilder migrationBuilder)
        {
            // ── Stations ────────────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "RailStations",
                columns: ["Id", "Code", "Name"],
                values: new object[,]
                {
                    { new Guid("a0000001-0000-0000-0000-000000000001"), "BJP", "北京南" },
                    { new Guid("a0000001-0000-0000-0000-000000000002"), "TNS", "天津南" },
                    { new Guid("a0000001-0000-0000-0000-000000000003"), "JNX", "济南西" },
                    { new Guid("a0000001-0000-0000-0000-000000000004"), "NJS", "南京南" },
                    { new Guid("a0000001-0000-0000-0000-000000000005"), "SHH", "上海虹桥" }
                });

            // ── Version ─────────────────────────────────────────────────────────
            var seedTime = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var emptyExtra = "{}";

            migrationBuilder.InsertData(
                table: "RailVersions",
                columns: ["Id", "Code", "EffectiveDate", "Description",
                          "ExtraProperties", "ConcurrencyStamp",
                          "CreationTime", "CreatorId",
                          "LastModificationTime", "LastModifierId",
                          "IsDeleted", "DeleterId", "DeletionTime"],
                values: new object[]
                {
                    new Guid("a0000002-0000-0000-0000-000000000001"),
                    "2026-01",
                    new DateOnly(2026, 1, 1),
                    "2026年01月调图",
                    emptyExtra, "SEED-VERSION",
                    seedTime, null,
                    null, null,
                    false, null, null
                });

            // ── Train ────────────────────────────────────────────────────────────
            var versionId = new Guid("a0000002-0000-0000-0000-000000000001");
            var trainId   = new Guid("a0000003-0000-0000-0000-000000000001");

            migrationBuilder.InsertData(
                table: "RailTrains",
                columns: ["Id", "VersionId", "Number", "Name",
                          "ExtraProperties", "ConcurrencyStamp",
                          "CreationTime", "CreatorId",
                          "LastModificationTime", "LastModifierId",
                          "IsDeleted", "DeleterId", "DeletionTime"],
                values: new object[]
                {
                    trainId, versionId,
                    "G1", "G1次（北京南—上海虹桥）",
                    emptyExtra, "SEED-TRAIN",
                    seedTime, null,
                    null, null,
                    false, null, null
                });

            // ── TrainStations ────────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "RailTrainStations",
                columns: ["Id", "TrainId", "StationId", "Sequence", "ArrivalOffset", "DepartureOffset"],
                values: new object[,]
                {
                    // Beijing South: origin — no arrival, departs at +0h
                    {
                        new Guid("a0000006-0000-0000-0000-000000000001"), trainId,
                        new Guid("a0000001-0000-0000-0000-000000000001"),
                        1, null, TimeSpan.Zero
                    },
                    // Tianjin South: +36 min / +38 min
                    {
                        new Guid("a0000006-0000-0000-0000-000000000002"), trainId,
                        new Guid("a0000001-0000-0000-0000-000000000002"),
                        2, TimeSpan.FromMinutes(36), TimeSpan.FromMinutes(38)
                    },
                    // Jinan West: +1h51m / +1h53m
                    {
                        new Guid("a0000006-0000-0000-0000-000000000003"), trainId,
                        new Guid("a0000001-0000-0000-0000-000000000003"),
                        3, TimeSpan.FromMinutes(111), TimeSpan.FromMinutes(113)
                    },
                    // Nanjing South: +4h03m / +4h05m
                    {
                        new Guid("a0000006-0000-0000-0000-000000000004"), trainId,
                        new Guid("a0000001-0000-0000-0000-000000000004"),
                        4, TimeSpan.FromMinutes(243), TimeSpan.FromMinutes(245)
                    },
                    // Shanghai Hongqiao: destination — arrives at +5h13m, no departure
                    {
                        new Guid("a0000006-0000-0000-0000-000000000005"), trainId,
                        new Guid("a0000001-0000-0000-0000-000000000005"),
                        5, TimeSpan.FromMinutes(313), null
                    }
                });

            // ── Formation ────────────────────────────────────────────────────────
            var formationId = new Guid("a0000004-0000-0000-0000-000000000001");

            migrationBuilder.InsertData(
                table: "RailFormations",
                columns: ["Id", "VersionId", "TrainId", "Code", "CoachCount",
                          "ExtraProperties", "ConcurrencyStamp",
                          "CreationTime", "CreatorId",
                          "LastModificationTime", "LastModifierId",
                          "IsDeleted", "DeleterId", "DeletionTime"],
                values: new object[]
                {
                    formationId, versionId, trainId,
                    "CRH380BL-16", (short)16,
                    emptyExtra, "SEED-FORMATION",
                    seedTime, null,
                    null, null,
                    false, null, null
                });

            // ── Route ────────────────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "RailRoutes",
                columns: ["Id", "VersionId", "TrainId", "FormationId",
                          "OriginStationId", "DestinationStationId", "Code",
                          "ExtraProperties", "ConcurrencyStamp",
                          "CreationTime", "CreatorId",
                          "LastModificationTime", "LastModifierId",
                          "IsDeleted", "DeleterId", "DeletionTime"],
                values: new object[]
                {
                    new Guid("a0000005-0000-0000-0000-000000000001"),
                    versionId, trainId, formationId,
                    new Guid("a0000001-0000-0000-0000-000000000001"),  // Beijing South
                    new Guid("a0000001-0000-0000-0000-000000000005"),  // Shanghai Hongqiao
                    "G1-BJP-SHH",
                    emptyExtra, "SEED-ROUTE",
                    seedTime, null,
                    null, null,
                    false, null, null
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "RailRoutes",
                keyColumn: "Id", keyValue: new Guid("a0000005-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(table: "RailFormations",
                keyColumn: "Id", keyValue: new Guid("a0000004-0000-0000-0000-000000000001"));

            for (var i = 1; i <= 5; i++)
            {
                migrationBuilder.DeleteData(table: "RailTrainStations",
                    keyColumn: "Id", keyValue: new Guid($"a0000006-0000-0000-0000-{i:D12}"));
            }

            migrationBuilder.DeleteData(table: "RailTrains",
                keyColumn: "Id", keyValue: new Guid("a0000003-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(table: "RailVersions",
                keyColumn: "Id", keyValue: new Guid("a0000002-0000-0000-0000-000000000001"));

            for (var i = 1; i <= 5; i++)
            {
                migrationBuilder.DeleteData(table: "RailStations",
                    keyColumn: "Id", keyValue: new Guid($"a0000001-0000-0000-0000-{i:D12}"));
            }

            migrationBuilder.DropTable(
                name: "RailFormations");

            migrationBuilder.DropTable(
                name: "RailRoutes");

            migrationBuilder.DropTable(
                name: "RailStations");

            migrationBuilder.DropTable(
                name: "RailTrainStations");

            migrationBuilder.DropTable(
                name: "RailVersions");

            migrationBuilder.DropTable(
                name: "RailTrains");
        }
    }
}
