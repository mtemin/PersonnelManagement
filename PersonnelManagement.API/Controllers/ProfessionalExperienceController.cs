using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Services;
using System.Xml;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.API.Controllers;

[Route("[action]")]
[ApiController]
public class ProfessionalExperienceController:ControllerBase
{
     private readonly IProfessionalExperienceService professionalExperienceService;
     private readonly IMapper mapper;

     public ProfessionalExperienceController(IProfessionalExperienceService service, IMapper _mapper)
     {
         this.professionalExperienceService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<IEnumerable<ProfessionalExperienceDTO>>> GetAllProfessionalExperiences()
     {
         var professionalExperience = await professionalExperienceService.GetAllEntitiesAsync();
         var professionalExperienceResources = mapper.Map<IEnumerable<ProfessionalExperience>, IEnumerable<ProfessionalExperienceDTO>>(professionalExperience);

         return Ok(professionalExperienceResources);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<ProfessionalExperienceDTO>> GetProfessionalExperience(int id)
     {
         var professionalExperience = await professionalExperienceService.GetEntityByIdAsync(id);
         if (professionalExperience == null)
         {
             return NotFound("ProfessionalExperience not found");
         }
    
         var professionalExperienceResource = mapper.Map<ProfessionalExperience, ProfessionalExperienceDTO>(professionalExperience);
         return Ok(professionalExperienceResource); // This should return a JSON response
     }

     [HttpPost]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<ProfessionalExperienceDTO>> CreateProfessionalExperience([FromBody] UpdateProfessionalExperienceDTO saveProfessionalExperienceResource)
     {
         var professionalExperienceToCreate = mapper.Map<UpdateProfessionalExperienceDTO, ProfessionalExperience>(saveProfessionalExperienceResource);

         var newProfessionalExperience = await professionalExperienceService.CreateEntityAsync(professionalExperienceToCreate);

         var professionalExperience = await professionalExperienceService.GetEntityByIdAsync(newProfessionalExperience.ProfessionalExperienceId);

         var professionalExperienceResource = mapper.Map<ProfessionalExperience, ProfessionalExperienceDTO>(professionalExperience);
         return Ok(professionalExperienceResource);
     }

     [HttpDelete]
     // [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteProfessionalExperience(int id)
     {
         if (id == 0)
             return BadRequest();

         var professionalExperience = await professionalExperienceService.GetEntityByIdAsync(id);

         if (professionalExperience == null)
             return NotFound();

         await professionalExperienceService.DeleteEntityAsync(professionalExperience);

         return NoContent();
     }
    

     [HttpPut]
     // [Authorize(Roles = "Admin,Founder")]
     public async Task<ActionResult<ProfessionalExperienceDTO>> UpdateProfessionalExperience(int id, [FromBody]UpdateProfessionalExperienceDTO saveProfessionalExperienceResource)
     {
         var professionalExperienceToBeUpdated = await professionalExperienceService.GetEntityByIdAsync(id);
     
         if (professionalExperienceToBeUpdated == null)
             return NotFound();
     
         var professionalExperience = mapper.Map<UpdateProfessionalExperienceDTO, ProfessionalExperience>(saveProfessionalExperienceResource);
     
         await professionalExperienceService.UpdateEntityAsync(professionalExperienceToBeUpdated, professionalExperience);
     
         var updatedProfessionalExperience = await professionalExperienceService.GetEntityByIdAsync(id);
         var updatedProfessionalExperienceResource = mapper.Map<ProfessionalExperience, ProfessionalExperienceDTO>(updatedProfessionalExperience);
         return Ok(updatedProfessionalExperienceResource);
     }
     
     [HttpGet("{id}")]  
     public async Task<ActionResult<IEnumerable<ProfessionalExperienceDTO>>> GetProfessionalExperiencesByEmployeeId(int id)
     {
         var professionalExperiences = await professionalExperienceService.GetProfessionalExperiencesByEmployeeIdAsync(id);
    
         if (professionalExperiences == null || !professionalExperiences.Any())
         {
             return NotFound("No professionalExperiences found for the specified company.");
         }

         var professionalExperienceResources = mapper.Map<IEnumerable<ProfessionalExperience>, IEnumerable<ProfessionalExperienceDTO>>(professionalExperiences);
    
         return Ok(professionalExperienceResources);
     }
     
}