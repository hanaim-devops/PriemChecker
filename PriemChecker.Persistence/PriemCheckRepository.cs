using Microsoft.EntityFrameworkCore;

namespace PriemChecker.Persistence;

public class PriemCheckRepository(PriemCheckContext context)
{
    public async Task VoegResultaatToeAsync(PriemCheckResultaatEntity resultaat)
    {
        context.PriemCheckResultaten.Add(resultaat);
        await context.SaveChangesAsync();
    }

    public async Task<List<PriemCheckResultaatEntity>> HaalAlleResultatenOpAsync()
    {
        return await context.PriemCheckResultaten.ToListAsync();
    }
}