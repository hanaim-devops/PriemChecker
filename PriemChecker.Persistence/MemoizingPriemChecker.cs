using System.Numerics;
using System.Transactions;
using PriemChecker.Abstractions;

namespace PriemChecker.Persistence;

public class MemoizingPriemChecker: IPriemChecker {
 
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
    
    public PriemCheckResultaat IsPriemgetal(BigInteger number)
    {
        Console.WriteLine($"IsPriemgetal: {number}");
        // Check of resultaat al in database staat.
        PriemCheckResultaatEntity existingResult = null;
        try
        {
            existingResult = _context.PriemCheckResultaten
                .FirstOrDefault(r => r.PriemKandidaatWaarde == number);
        }
        catch (Microsoft.Data.SqlClient.SqlException e)
        {
            throw new PriemDatabaseException("Database lijkt offline.");
        }

        if (existingResult != null)
        {
            return new PriemCheckResultaat(
                existingResult.PriemKandidaatWaarde, 
                existingResult.IsPriemgetal, 
                existingResult.AantalLoops,
                null
                );
        }

        // Anders de interne service gebruiken om te berekenen.
        var result = _innerService.IsPriemgetal(number);

        var huidigeDateTime = DateTime.UtcNow;
        
        // Resultaat opslaan in database
        _context.PriemCheckResultaten.Add(new PriemCheckResultaatEntity(
            number,
            result.IsPriemgetal,
            huidigeDateTime,
            result.AantalSecondenOmTeBerekenen,
            result.AantalLoops
            ));
        _context.SaveChanges();

        return result;
    }
}