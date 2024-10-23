using System.Numerics;
using Open.Numeric.Primes;

using PriemChecker.Abstractions;

namespace PriemChecker.Domain;

public class NuGetPriemChecker: IPriemChecker
{
    public PriemCheckResultaat IsPriemgetal(double kandidaat)
    {
        var isPriemgetal = Number.IsPrime(kandidaat);
        return new PriemCheckResultaat((BigInteger) kandidaat, isPriemgetal, null, null, null);
    }

    public PriemCheckResultaat IsPriemgetal(BigInteger kandidaat)
    {
        var isPriemgetal = Number.IsPrime(kandidaat);
        // var isPriemgetal = kandidaat.isProbablePrime(1);
        return new PriemCheckResultaat(kandidaat, isPriemgetal, null, null, null);
    }

}