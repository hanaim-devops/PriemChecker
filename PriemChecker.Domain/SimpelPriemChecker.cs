using PriemChecker.Abstractions;

namespace PriemChecker.Domain;

public class SimpelPriemChecker: IPriemChecker
{
    public Boolean IsPriemgetal(int kandidaat, out int aantalLoops)
    {
        // Als het getal kleiner is dan 2, is het geen priemgetal.
        if (kandidaat < 2)
        {
            aantalLoops = 0;
            return false;
        }

        aantalLoops = 0;
        // Controleer divisors tot en met de vierkantswortel van de kandidaat.
        for (int deler = 2; deler <= Math.Sqrt(kandidaat); deler++)
        {
            aantalLoops++;
            if (kandidaat % deler == 0) {
                return false; // Als er een deler is, is het geen priemgetal.
            }
        }

        // Als geen delers zijn gevonden, is het getal een priemgetal.
        return true;
    }

    public Boolean IsPriemgetal(int kandidaat)
    {
        return IsPriemgetal(kandidaat, out _);
    }
}