namespace PriemCheckerLibrary;

public class MemoizingPriemChecker(PriemCheckContext context, NuGetPriemChecker innerService) : PriemChecker
{
    public bool IsPriemgetal(int number)
    {
        // Check of resultaat al in database staat
        var existingResult = context.PriemCheckResultaten
            .FirstOrDefault(r => r.priemKandidaatWaarde == number);

        if (existingResult != null)
        {
            return existingResult.isPriemgetal;
        }

        // Anders de interne service gebruiken om te berekenen.
        var result = innerService.IsPriemgetal(number);

        // Resultaat opslaan in database
        context.PriemCheckResultaten.Add(new PriemCheckResultaat(number, result));
        context.SaveChanges();

        return result;
    }
}
