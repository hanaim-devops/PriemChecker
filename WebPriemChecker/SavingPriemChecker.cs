namespace PriemCheckerLibrary;

public class PriemCheckerMetPersistentie: PriemChecker
{
    // Gebruik decorator pattern.
    private PriemChecker priemChecker = new NuGetPriemChecker();

    public bool IsPriemgetal(int kandidaat)
    {
        // Roep interne
        var result = priemChecker.IsPriemgetal(kandidaat);
        
        // En sla daarna resultaat op in PrimeCheckRepository.
        var toSave = new PriemCheckResultaat(kandidaat, result);
        // TODO: PriemCheckRepository.save(toSave);

        return result;
    }
}