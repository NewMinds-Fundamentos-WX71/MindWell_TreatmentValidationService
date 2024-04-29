using MindWell_TreatmentValidation.Shared.Persistence.Repositories;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Communication;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Repositories;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Services;

namespace MindWell_TreatmentValidation.TreatmentValidation.Services;

public class TreatmentValidationService : ITreatmentValidationService
{
    private readonly ITreatmentValidationRepository _treatmentValidationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TreatmentValidationService(ITreatmentValidationRepository treatmentValidationRepository, IUnitOfWork unitOfWork)
    {
        _treatmentValidationRepository = treatmentValidationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.TreatmentValidation>> ListAsync()
    {
        return await _treatmentValidationRepository.ListAsync();
    }

    public async Task<Domain.Models.TreatmentValidation> GetByIdAsync(int id)
    {
        return await _treatmentValidationRepository.FindByIdAsync(id);
    }

    public async Task<TreatmentValidationResponse> SaveAsync(Domain.Models.TreatmentValidation treatmentValidation)
    {
        try
        {
            await _treatmentValidationRepository.AddAsync(treatmentValidation);
            await _unitOfWork.CompleteAsync();
            return new TreatmentValidationResponse(treatmentValidation);
        }
        catch (Exception e)
        {
            return new TreatmentValidationResponse($"An error occurred while saving the treatmentValidation: {e.Message}");
        }
    }

    public async Task<TreatmentValidationResponse> UpdateAsync(int id, Domain.Models.TreatmentValidation treatmentValidation)
    {
        try
        {
            var existingTreatmentValidation = await _treatmentValidationRepository.FindByIdAsync(id);

            if (existingTreatmentValidation == null)
                return new TreatmentValidationResponse("TreatmentValidation not found.");

            existingTreatmentValidation.Lifespan = treatmentValidation.Lifespan;
            existingTreatmentValidation.Counter = treatmentValidation.Counter;

            _treatmentValidationRepository.Update(existingTreatmentValidation);
            await _unitOfWork.CompleteAsync();
            return new TreatmentValidationResponse(existingTreatmentValidation);
        }
        catch (Exception e)
        {
            return new TreatmentValidationResponse($"An error occurred while updating the treatmentValidation: {e.Message}");
        }
    }

    public async Task<TreatmentValidationResponse> DeleteAsync(int id)
    {
        try
        {
            var existingTreatmentValidation = await _treatmentValidationRepository.FindByIdAsync(id);

            if (existingTreatmentValidation == null)
                return new TreatmentValidationResponse("TreatmentValidation not found.");

            _treatmentValidationRepository.Remove(existingTreatmentValidation);
            await _unitOfWork.CompleteAsync();
            return new TreatmentValidationResponse(existingTreatmentValidation);
        }
        catch (Exception e)
        {
            return new TreatmentValidationResponse($"An error occurred while deleting the treatmentValidation: {e.Message}");
        }
    }
}