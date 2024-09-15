using Microsoft.EntityFrameworkCore;

namespace WebPriemChecker;

public class PriemCheckContext : DbContext
{
    public DbSet<PriemCheckResultaat> PriemCheckResultaten { get; set; }

    public PriemCheckContext(DbContextOptions<PriemCheckContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriemCheckResultaat>().HasKey(p => p.priemKandidaatWaarde);
    }
}
