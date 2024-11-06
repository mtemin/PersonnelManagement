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
public class EducationController:ControllerBase
{
     private readonly IEducationService educationService;
     private readonly IMapper mapper;

     public EducationController(IEducationService service, IMapper _mapper)
     {
         this.educationService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<IEnumerable<EducationDTO>>> GetAllEducations()
     {
         var education = await educationService.GetAllEntitiesAsync();
         var educationResources = mapper.Map<IEnumerable<Education>, IEnumerable<EducationDTO>>(education);

         return Ok(educationResources);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<EducationDTO>> GetEducation(int id)
     {
         var education = await educationService.GetEntityByIdAsync(id);
         if (education == null)
         {
             return NotFound("Education not found");
         }
    
         var educationResource = mapper.Map<Education, EducationDTO>(education);
         return Ok(educationResource); // This should return a JSON response
     }

     [HttpPost]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<EducationDTO>> CreateEducation([FromBody] UpdateEducationDTO saveEducationResource)
     {
         var educationToCreate = mapper.Map<UpdateEducationDTO, Education>(saveEducationResource);

         var newEducation = await educationService.CreateEntityAsync(educationToCreate);

         var education = await educationService.GetEntityByIdAsync(newEducation.EducationId);

         var educationResource = mapper.Map<Education, EducationDTO>(education);
         return Ok(educationResource);
     }

     [HttpDelete]
     // [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteEducation(int id)
     {
         if (id == 0)
             return BadRequest();

         var education = await educationService.GetEntityByIdAsync(id);

         if (education == null)
             return NotFound();

         await educationService.DeleteEntityAsync(education);

         return NoContent();
     }
    

     [HttpPut]
     // [Authorize(Roles = "Admin,Founder")]
     public async Task<ActionResult<EducationDTO>> UpdateEducation(int id, [FromBody]UpdateEducationDTO saveEducationResource)
     {
         var educationToBeUpdated = await educationService.GetEntityByIdAsync(id);
     
         if (educationToBeUpdated == null)
             return NotFound();
     
         var education = mapper.Map<UpdateEducationDTO, Education>(saveEducationResource);
     
         await educationService.UpdateEntityAsync(educationToBeUpdated, education);
     
         var updatedEducation = await educationService.GetEntityByIdAsync(id);
         var updatedEducationResource = mapper.Map<Education, EducationDTO>(updatedEducation);
         return Ok(updatedEducationResource);
     }
     
     [HttpGet("{id}")] 
     public async Task<ActionResult<IEnumerable<EducationDTO>>> GetEducationsByEmployeeId(int id)
     {
         var educations = await educationService.GetEducationsByEmployeeIdAsync(id);
    
         if (educations == null || !educations.Any())
         {
             return NotFound("No educations found for the specified company.");
         }

         var employeeResources = mapper.Map<IEnumerable<Education>, IEnumerable<EducationDTO>>(educations);
    
         return Ok(employeeResources);
     }
     
}