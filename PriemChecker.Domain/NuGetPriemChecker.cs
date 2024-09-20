using Open.Numeric.Primes;
using PriemChecker.Abstractions;

namespace PriemChecker.Domain;

public class NuGetPriemChecker: IPriemChecker
{
    public Boolean IsPriemgetal(int kandidaat)
    {
        return Number.IsPrime(kandidaat);
    }

    public Boolean IsPriemgetal(BigInteger kandidaat)
    {
        return kandidaat.isProbablePrime(1);
    }

}