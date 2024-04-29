using AutoMapper;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Models;
using MindWell_TreatmentValidation.TreatmentValidation.Resources.POST;

namespace MindWell_TreatmentValidation.TreatmentValidation.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveTreatmentValidationResource, Domain.Models.TreatmentValidation>();
    }
}