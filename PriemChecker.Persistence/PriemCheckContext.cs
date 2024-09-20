using Microsoft.EntityFrameworkCore;

namespace PriemChecker.Persistence;

public class PriemCheckContext : DbContext
{
    public DbSet<PriemCheckResultaatEntity> PriemCheckResultaten { get; set; }

    // Parameterloze constructor voor design-time.
    // Zie: https://chatgpt.com/share/66e9f021-d8a8-8012-a6dc-a4ad86f3f3b6
    public PriemCheckContext() { }
    public PriemCheckContext(DbContextOptions<PriemCheckContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriemCheckResultaatEntity>()
            .Property(p => p.PriemKandidaatWaarde)
            .ValueGeneratedNever();  // PriemKandidaatWaarde is not Identity
    }
}
