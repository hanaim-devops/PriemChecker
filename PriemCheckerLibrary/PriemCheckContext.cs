using Microsoft.EntityFrameworkCore;

namespace PriemCheckerLibrary;

public class PriemCheckContext : DbContext
{
    public DbSet<PriemCheckResultaat> PriemCheckResultaten { get; set; }

    // Parameterloze constructor voor design-time.
    // Zie: https://chatgpt.com/share/66e9f021-d8a8-8012-a6dc-a4ad86f3f3b6
    public PriemCheckContext() { }
    public PriemCheckContext(DbContextOptions<PriemCheckContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriemCheckResultaat>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();  // Alleen Id is Identity.

        modelBuilder.Entity<PriemCheckResultaat>()
            .Property(p => p.PriemKandidaatWaarde)
            .ValueGeneratedNever();  // Dit zorgt ervoor dat PriemKandidaatWaarde geen Identity krijgt.
    }
}
