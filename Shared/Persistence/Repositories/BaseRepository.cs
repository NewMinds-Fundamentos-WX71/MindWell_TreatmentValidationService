using MindWell_TreatmentValidation.Shared.Persistence.Contexts;

namespace MindWell_TreatmentValidation.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}