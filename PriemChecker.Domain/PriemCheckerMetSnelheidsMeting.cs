using System.Diagnostics;
using System.Numerics;
using PriemChecker.Abstractions;

namespace PriemChecker.Domain;

public class PriemCheckerMetSnelheidsMeting(IPriemChecker priemChecker) : IPriemChecker
{
    public PriemCheckResultaat IsPriemgetal(BigInteger kandidaat)
    {
        // Start de stopwatch
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Roep de innerlijke priemchecker aan
        var innerPriemCheckResultaat = priemChecker.IsPriemgetal(kandidaat);

        // Stop de stopwatch en meet de verstreken tijd
        stopwatch.Stop();
        var aantalMilliSecondenOmTeBerekenen = stopwatch.ElapsedMilliseconds;
        var aantalTicksOmTeBerekenen = stopwatch.ElapsedTicks;

        Console.WriteLine($"Priemgetal check voor {kandidaat} duurde {aantalMilliSecondenOmTeBerekenen} ms over {aantalTicksOmTeBerekenen} ticks.");

        return new PriemCheckResultaat(
            innerPriemCheckResultaat.PriemKandidaatWaarde,
            innerPriemCheckResultaat.IsPriemgetal,
            innerPriemCheckResultaat.AantalLoops,
            aantalMilliSecondenOmTeBerekenen,
            aantalTicksOmTeBerekenen
       );
    }
}