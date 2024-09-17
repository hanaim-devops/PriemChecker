using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriemCheckerLibrary;

public record PriemCheckResultaat
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }  // Mutable property for EF Core to set automatically
    public int PriemKandidaatWaarde { get; init; }  // Immutable property
    public bool IsPriemgetal { get; init; }  // Immutable property

    
    public PriemCheckResultaat(int priemKandidaatWaarde, bool isPriemgetal)
    {
        PriemKandidaatWaarde = priemKandidaatWaarde;
        IsPriemgetal = isPriemgetal;
    }
}
