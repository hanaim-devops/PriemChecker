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
            v => v.ToString(),
            v => BigInteger.Parse(v)
        );

        // Configureer PriemKandidaatWaarde als de primaire sleutel
        modelBuilder.Entity<PriemCheckResultaatEntity>()
            .HasKey(p => p.PriemKandidaatWaarde);

        modelBuilder.Entity<PriemCheckResultaatEntity>()
            .Property(p => p.PriemKandidaatWaarde)
            .HasConversion(bigIntegerConverter) // Converteer BigInteger naar string
            .ValueGeneratedNever(); // Omdat je de waarde zelf opgeeft, niet door de database laten genereren

        // Andere kolomconfiguraties
    }

}
