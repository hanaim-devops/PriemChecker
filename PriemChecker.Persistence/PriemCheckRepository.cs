using Microsoft.EntityFrameworkCore;

namespace PriemChecker.Persistence;

// TODO: Naar eigen 'Persistence' library verplaatsen i.v.m. Layer pattern en 'modular monolith'?
public class PriemCheckRepository
{
    
    private readonly PriemCheckContext _context;

    public PriemCheckRepository(PriemCheckContext context)
    {
        _context = context;
    }

    public async Task VoegResultaatToeAsync(PriemCheckResultaatEntity resultaat)
    {
        _context.PriemCheckResultaten.Add(resultaat);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PriemCheckResultaatEntity>> HaalAlleResultatenOpAsync()
    {
        return await _context.PriemCheckResultaten.ToListAsync();
    }
}