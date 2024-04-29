using MindWell_TreatmentValidation.TreatmentValidation.Domain.Communication;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Models;

namespace MindWell_TreatmentValidation.TreatmentValidation.Domain.Services;

public interface ITreatmentValidationService
{
    Task<IEnumerable<Models.TreatmentValidation>> ListAsync();
    Task<Models.TreatmentValidation> GetByIdAsync(int id);
    Task<TreatmentValidationResponse> SaveAsync(Models.TreatmentValidation treatmentValidation);
    Task<TreatmentValidationResponse> UpdateAsync(int id, Models.TreatmentValidation treatmentValidation);
    Task<TreatmentValidationResponse> DeleteAsync(int id);
}