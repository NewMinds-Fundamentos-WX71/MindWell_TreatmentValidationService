using AutoMapper;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Models;
using MindWell_TreatmentValidation.TreatmentValidation.Resources.GET;

namespace MindWell_TreatmentValidation.TreatmentValidation.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.TreatmentValidation, TreatmentValidationResource>();
    }
}