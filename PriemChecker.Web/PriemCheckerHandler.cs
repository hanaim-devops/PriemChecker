using PriemChecker.Abstractions;

namespace PriemChecker.Web;

public class PriemCheckerHandler
{
    public static IResult IsPriem(IPriemChecker priemgetalChecker, int getal)
    {
        var result = priemgetalChecker.IsPriemgetal(getal);
        return Results.Ok(result);
    }
}