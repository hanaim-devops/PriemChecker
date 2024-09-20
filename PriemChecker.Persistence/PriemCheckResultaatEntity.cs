namespace PriemChecker.Persistence;

public class PriemCheckResultaatEntity
{
    public int Id { get; set; }  // Identity column for persistence
    public int PriemKandidaatWaarde { get; set; }
    public bool IsPriemgetal { get; set; }
    
    // Parameterless constructor for EF Core
    public PriemCheckResultaatEntity() {}
    
    // Optional constructor for manual instantiation
    public PriemCheckResultaatEntity(int number, bool result)
    {
        PriemKandidaatWaarde = number;
        IsPriemgetal = result;
    }
}
