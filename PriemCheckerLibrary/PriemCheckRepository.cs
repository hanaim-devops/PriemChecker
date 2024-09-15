using Microsoft.EntityFrameworkCore;

namespace PriemCheckerLibrary;

// TODO: Naar eigen 'Persistence' library verplaatsen i.v.m. Layer pattern?
public class PriemCheckRepository
{
    
    private readonly PriemCheckContext _context;

    public PriemCheckRepository(PriemCheckContext context)
    {
        _context = context;
    }

    public async Task VoegResultaatToeAsync(PriemCheckResultaat resultaat)
    {
        _context.PriemCheckResultaten.Add(resultaat);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PriemCheckResultaat>> HaalAlleResultatenOpAsync()
    {
        return await _context.PriemCheckResultaten.ToListAsync();
    }
}