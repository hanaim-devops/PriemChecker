using PriemChecker.Abstractions;

namespace PriemCheckerLibrary;

public class MemoizingPriemChecker: IPriemChecker
{
 
    private readonly PriemCheckContext _context;
    private readonly IPriemChecker _innerService;

    // Constructor
    public MemoizingPriemChecker(PriemCheckContext context, IPriemChecker innerService)
    {
        // Controleer of innerService een MemoizingPriemChecker is
        if (innerService is MemoizingPriemChecker)
        {
            throw new InvalidOperationException("MemoizingPriemChecker cannot wrap another MemoizingPriemChecker to avoid an infinite loop.");
        }

        _context = context;
        _innerService = innerService;
    }
    
    public bool IsPriemgetal(int number)
    {
        // Check of resultaat al in database staat
        var existingResult = _context.PriemCheckResultaten
            .FirstOrDefault(r => r.PriemKandidaatWaarde == number);

        if (existingResult != null)
        {
            return existingResult.IsPriemgetal;
        }

        // Anders de interne service gebruiken om te berekenen.
        var result = _innerService.IsPriemgetal(number);

        // Resultaat opslaan in database
        _context.PriemCheckResultaten.Add(new PriemCheckResultaat(number, result));
        _context.SaveChanges();

        return result;
    }
}
