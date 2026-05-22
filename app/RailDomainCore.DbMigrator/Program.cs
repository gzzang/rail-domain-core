using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RailDomainCore.EntityFrameworkCore;

namespace RailDomainCore.DbMigrator;

public class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("ConnectionStrings:Default is required.");

        var options = new DbContextOptionsBuilder<RailDomainCoreDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        await using var dbContext = new RailDomainCoreDbContext(options);
        await dbContext.Database.MigrateAsync();
    }
}
