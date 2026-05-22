using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RailDomainCore.EntityFrameworkCore;

public class RailDomainCoreDbContextFactory : IDesignTimeDbContextFactory<RailDomainCoreDbContext>
{
    public RailDomainCoreDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RailDomainCoreDbContext>()
            .UseNpgsql(GetConnectionStringFromArgs(args));

        return new RailDomainCoreDbContext(builder.Options);
    }

    private static string GetConnectionStringFromArgs(string[] args)
    {
        // Allow passing connection string via --connection argument at design time:
        //   dotnet ef migrations add MyMigration -- --connection "Host=...;..."
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (args[i].Equals("--connection", StringComparison.OrdinalIgnoreCase))
            {
                return args[i + 1];
            }
        }

        // Fall back to the CONNECTIONSTRINGS__DEFAULT environment variable so that
        // credentials are never hard-coded in source code.
        var envConnectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__DEFAULT");
        if (!string.IsNullOrWhiteSpace(envConnectionString))
        {
            return envConnectionString;
        }

        throw new InvalidOperationException(
            "No connection string found for design-time migration. " +
            "Pass one via '--connection <connStr>' or set the CONNECTIONSTRINGS__DEFAULT environment variable.");
    }
}
