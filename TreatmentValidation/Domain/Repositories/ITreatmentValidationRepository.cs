namespace MindWell_TreatmentValidation.TreatmentValidation.Domain.Repositories;

public interface ITreatmentValidationRepository
{
    Task<IEnumerable<Models.TreatmentValidation>> ListAsync();
    Task<Models.TreatmentValidation> FindByIdAsync(int id);
    Task AddAsync(Models.TreatmentValidation treatmentValidation);
    void Update(Models.TreatmentValidation treatmentValidation);
    void Remove(Models.TreatmentValidation treatmentValidation);
}