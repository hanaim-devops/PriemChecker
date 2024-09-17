using Microsoft.Extensions.Configuration;

namespace PriemCheckerLibrary;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class PriemCheckContextFactory : IDesignTimeDbContextFactory<PriemCheckContext>
{
    public PriemCheckContext CreateDbContext(string[] args)
    {
        // Haal de huidige directory op waar het project zich bevindt.
        var currentDirectory = Directory.GetCurrentDirectory();

        // Bouw de configuratie door het appsettings.json en appsettings.Development.json in te laden.
        var configuration = new ConfigurationBuilder()
            .SetBasePath(currentDirectory)
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Haal de connectiestring op uit de configuratie.
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<PriemCheckContext>();
        optionsBuilder.UseSqlServer(connectionString);
        // optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PriemCheckDb;User=sa;Password=Your_password123;TrustServerCertificate=True;");

        return new PriemCheckContext(optionsBuilder.Options);
    }
}
