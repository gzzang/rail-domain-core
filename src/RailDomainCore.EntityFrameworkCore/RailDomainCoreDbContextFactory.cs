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
        // Allow passing connection string via --connection argument at design time.
        for (var i = 0; i < args.Length - 1; i++)
        {
            if (args[i].Equals("--connection", StringComparison.OrdinalIgnoreCase))
            {
                return args[i + 1];
            }
        }

        return "Host=localhost;Port=5432;Database=RailDomainCore;Username=postgres;Password=postgres";
    }
}
