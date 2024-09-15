using Open.Numeric.Primes;

namespace PriemCheckerLibrary;

public class NuGetPriemChecker : PriemChecker
{

    private BigInteger bigInteger;
   
    public Boolean IsPriemgetal(int kandidaat)
    {
        return Number.IsPrime(kandidaat);
    }

    public Boolean IsPriemgetal(BigInteger kandidaat)
    {
        return kandidaat.isProbablePrime(1);
    }

}