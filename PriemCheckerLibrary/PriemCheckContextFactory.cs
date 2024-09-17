namespace PriemCheckerLibrary;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class PriemCheckContextFactory : IDesignTimeDbContextFactory<PriemCheckContext>
{
    public PriemCheckContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PriemCheckContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PriemCheckDb;User=sa;Password=Your_password123;");

        return new PriemCheckContext(optionsBuilder.Options);
    }
}
