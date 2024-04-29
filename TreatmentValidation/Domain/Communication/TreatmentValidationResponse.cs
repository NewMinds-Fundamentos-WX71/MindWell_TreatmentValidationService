using MindWell_TreatmentValidation.Shared.Domain.Services.Communication;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Models;

namespace MindWell_TreatmentValidation.TreatmentValidation.Domain.Communication;

public class TreatmentValidationResponse : BaseResponse<Models.TreatmentValidation>
{
    public TreatmentValidationResponse(string message) : base(message)
    {
    }

    public TreatmentValidationResponse(Models.TreatmentValidation resource) : base(resource)
    {
    }
}