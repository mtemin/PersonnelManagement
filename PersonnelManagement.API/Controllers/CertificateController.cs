using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Services;
using System.Xml;

namespace PersonnelManagement.API.Controllers;

[Route("[action]")]
[ApiController]
public class CertificateController:ControllerBase
{
     private readonly ICertificateService certificateService;
     private readonly IMapper mapper;

     public CertificateController(ICertificateService service, IMapper _mapper)
     {
         this.certificateService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<IEnumerable<CertificateDTO>>> GetAllCertificates()
     {
         var companies = await certificateService.GetAllEntitiesAsync();
         var companiesResources = mapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateDTO>>(companies);

         return Ok(companiesResources);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<CertificateDTO>> GetCertificate(int id)
     {
         var certificate = await certificateService.GetEntityByIdAsync(id);
         if (certificate == null)
         {
             return NotFound("Certificate not found");
         }
    
         var certificateResource = mapper.Map<Certificate, CertificateDTO>(certificate);
         return Ok(certificateResource); // This should return a JSON response
     }

     [HttpPost]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<CertificateDTO>> CreateCertificate([FromBody] UpdateCertificateDTO saveCertificateResource)
     {
         var certificateToCreate = mapper.Map<UpdateCertificateDTO, Certificate>(saveCertificateResource);

         var newCertificate = await certificateService.CreateEntityAsync(certificateToCreate);

         var certificate = await certificateService.GetEntityByIdAsync(newCertificate.CertificateId);

         var certificateResource = mapper.Map<Certificate, CertificateDTO>(certificate);
         return Ok(certificateResource);
     }

     [HttpDelete]
     // [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteCertificate(int id)
     {
         if (id == 0)
             return BadRequest();

         var certificate = await certificateService.GetEntityByIdAsync(id);

         if (certificate == null)
             return NotFound();

         await certificateService.DeleteEntityAsync(certificate);

         return NoContent();
     }
    

     [HttpPut]
     // [Authorize(Roles = "Admin,Founder")]
     public async Task<ActionResult<CertificateDTO>> UpdateCertificate(int id, [FromBody]UpdateCertificateDTO saveCertificateResource)
     {
         var certificateToBeUpdated = await certificateService.GetEntityByIdAsync(id);
     
         if (certificateToBeUpdated == null)
             return NotFound();
     
         var certificate = mapper.Map<UpdateCertificateDTO, Certificate>(saveCertificateResource);
     
         await certificateService.UpdateEntityAsync(certificateToBeUpdated, certificate);
     
         var updatedCertificate = await certificateService.GetEntityByIdAsync(id);
         var updatedCertificateResource = mapper.Map<Certificate, CertificateDTO>(updatedCertificate);
         return Ok(updatedCertificateResource);
     }
     
     [HttpGet("{id}")]
     public async Task<ActionResult<IEnumerable<CertificateDTO>>> GetCertificatesByEmployeeId(int id)
     {
         var certificates = await certificateService.GetCertificatesByEmployeeIdAsync(id);
         var certificateList = certificates.ToList();
    
         if (certificateList.Count() == 0)
         {
             return NotFound("No certificates found for the specified employee.");
         }

         var employeeResources = mapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateDTO>>(certificates);
    
         return Ok(employeeResources);
     }
     
}