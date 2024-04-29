using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_TreatmentValidation.Shared.Extensions;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Models;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Services;
using MindWell_TreatmentValidation.TreatmentValidation.Resources.GET;
using MindWell_TreatmentValidation.TreatmentValidation.Resources.POST;

namespace MindWell_TreatmentValidation.TreatmentValidation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TreatmentValidationsController : ControllerBase
{
    private readonly ITreatmentValidationService _treatmentValidationService;
    private readonly IMapper _mapper;

    public TreatmentValidationsController(ITreatmentValidationService treatmentValidationservice, IMapper mapper)
    {
        _treatmentValidationService = treatmentValidationservice;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TreatmentValidationResource>> GetAllAsync()
    {
        var treatmentValidations = await _treatmentValidationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.TreatmentValidation>, IEnumerable<TreatmentValidationResource>>(treatmentValidations);
        
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTreatmentValidationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var treatmentValidationing = _mapper.Map<SaveTreatmentValidationResource, Domain.Models.TreatmentValidation>(resource);
        var result = await _treatmentValidationService.SaveAsync(treatmentValidationing);

        if (!result.Success)
            return BadRequest(result.Message);

        var treatmentValidationingResource = _mapper.Map<Domain.Models.TreatmentValidation, TreatmentValidationResource>(result.Resource);

        return Ok(treatmentValidationingResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTreatmentValidationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var treatmentValidationing = _mapper.Map<SaveTreatmentValidationResource, Domain.Models.TreatmentValidation>(resource);
        var result = await _treatmentValidationService.UpdateAsync(id, treatmentValidationing);

        if (!result.Success)
            return BadRequest(result.Message);

        var treatmentValidationingResource = _mapper.Map<Domain.Models.TreatmentValidation, TreatmentValidationResource>(result.Resource);

        return Ok(treatmentValidationingResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _treatmentValidationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var treatmentValidationingResource = _mapper.Map<Domain.Models.TreatmentValidation, TreatmentValidationResource>(result.Resource);

        return Ok(treatmentValidationingResource);
    }
}