using Microsoft.Extensions.Configuration;

namespace PriemChecker.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class PriemCheckContextFactory : IDesignTimeDbContextFactory<PriemCheckContext>
{
    public PriemCheckContext CreateDbContext(string[] args)
    {
        // Set the base path to the PriemChecker.Web project directory
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../PriemChecker.Web");

        // Build configuration to load appsettings.json from PriemChecker.Web project
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath) // This sets the base path to the PriemChecker.Web directory
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Get the connection string from the configuration
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<PriemCheckContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new PriemCheckContext(optionsBuilder.Options);
    }
}
