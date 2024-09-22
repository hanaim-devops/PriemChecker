using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        // Definieer de BigInteger naar string converter.
        // Zie verder `docs/ADR/ORM-EF-Core-Value-Converter.md`
        var bigIntegerConverter = new ValueConverter<BigInteger, string>(
            v => v.ToString(), // Converteer BigInteger naar string bij opslaan
            v => BigInteger.Parse(v) // Converteer string terug naar BigInteger bij uitlezen
        );

        // Configureer de PriemKandidaatWaarde eigenschap met de ValueConverter en zorg ervoor dat deze geen Identity is.
        modelBuilder.Entity<PriemCheckResultaatEntity>()
            .Property(p => p.PriemKandidaatWaarde)
            .HasConversion(bigIntegerConverter) // Pas de ValueConverter toe
            .ValueGeneratedNever(); // PriemKandidaatWaarde is geen Identity (geen auto-generatie)
    }
}
