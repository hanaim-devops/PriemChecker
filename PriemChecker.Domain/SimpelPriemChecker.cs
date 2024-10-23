using System.Numerics;
using PriemChecker.Abstractions;

namespace PriemChecker.Domain;

public class SimpelPriemChecker: IPriemChecker
{
    public PriemCheckResultaat IsPriemgetal(BigInteger kandidaat)
    {
        // Als het getal kleiner is dan 2, is het geen priemgetal.
        if (kandidaat < 2)
        {
            return new PriemCheckResultaat(
                kandidaat, 
                false,
                0,
                null,
                null);
        }

        int? aantalLoops = 0;
        // Controleer divisors tot en met de vierkantswortel van de kandidaat.
        for (int deler = 2; deler <= kandidaat.Sqrt(); deler++)
        {
            aantalLoops++;
            if (kandidaat % deler == 0) {
                // Als er een deler is, is het geen priemgetal.
                return new PriemCheckResultaat(
                    kandidaat, 
                    false, 
                    aantalLoops, 
                    null,
                    null);
            }
        }

        // Als geen delers zijn gevonden, is het getal een priemgetal.
        return new PriemCheckResultaat(
            kandidaat, 
            true, 
            aantalLoops, 
            null,
            null);
    }
}