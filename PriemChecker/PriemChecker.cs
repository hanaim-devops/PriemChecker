
namespace PrimeChecker;

public class PriemChecker
{
    public Boolean IsPriemgetal(int kandidaat)
    {
        // Als het getal kleiner is dan 2, is het geen priemgetal.
        if (kandidaat < 2)
        {
            return false;
        }

        // Controleer divisors tot en met de vierkantswortel van de kandidaat.
        for (int deler = 2; deler <= Math.Sqrt(kandidaat); deler++)
        {
            if (kandidaat % deler == 0) {
                return false; // Als er een deler is, is het geen priemgetal.
            }
        }

        // Als geen delers zijn gevonden, is het getal een priemgetal.
        return true;
    }
}