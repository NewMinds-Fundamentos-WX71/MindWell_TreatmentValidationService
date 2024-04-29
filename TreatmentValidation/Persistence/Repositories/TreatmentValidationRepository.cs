using Microsoft.EntityFrameworkCore;
using MindWell_TreatmentValidation.Shared.Persistence.Contexts;
using MindWell_TreatmentValidation.Shared.Persistence.Repositories;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Repositories;

namespace MindWell_TreatmentValidation.TreatmentValidation.Persistence.Repositories;

public class TreatmentValidationRepository : BaseRepository, ITreatmentValidationRepository
{
    public TreatmentValidationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.TreatmentValidation>> ListAsync()
    {
        return await _context.TreatmentValidations.ToListAsync();
    }

    public async Task<Domain.Models.TreatmentValidation> FindByIdAsync(int id)
    {
        return await _context.TreatmentValidations.FindAsync(id);
    }

    public async Task AddAsync(Domain.Models.TreatmentValidation treatmentValidation)
    {
        await _context.TreatmentValidations.AddAsync(treatmentValidation);
    }

    public void Update(Domain.Models.TreatmentValidation treatmentValidation)
    {
        _context.Update(treatmentValidation);
    }

    public void Remove(Domain.Models.TreatmentValidation treatmentValidation)
    {
        _context.TreatmentValidations.Remove(treatmentValidation);
    }
}