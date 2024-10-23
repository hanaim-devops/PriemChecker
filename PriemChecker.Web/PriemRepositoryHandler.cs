using Microsoft.AspNetCore.Mvc;
using PriemChecker.Abstractions;
using PriemChecker.Persistence;

namespace PriemChecker.Web;
public class PriemRepositoryHandler
{
    public static async Task<IResult> HaalAllePriemGetallenOpAsync([FromServices] PriemCheckRepository priemCheckRepository)
    {
        var resultaten = await priemCheckRepository.HaalAlleResultatenOpAsync();
        
        // Convert each entity to the PriemCheckResultaat record (which has string for PriemKandidaatWaarde)
        var resultaatModels = resultaten.Select(r => new PriemCheckResultaat(
            r.PriemKandidaatWaarde.ToString(),   // Convert BigInteger to string
            r.IsPriemgetal,
            r.AantalLoops,
            r.MilliSecondenOmTeBerekenen,
            r.TicksOmTeBerekenen
        )).ToList();
        
        return Results.Ok(resultaatModels);
    }
}