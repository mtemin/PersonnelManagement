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
public class CompanyController:ControllerBase
{
     private readonly ICompanyService companyService;
     private readonly IMapper mapper;

     public CompanyController(ICompanyService service, IMapper _mapper)
     {
         this.companyService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAllCompanies()
     {
         var companies = await companyService.GetAllEntitiesAsync();
         var companiesResources = mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDTO>>(companies);

         return Ok(companiesResources);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
     {
         var company = await companyService.GetEntityByIdAsync(id);
         if (company == null)
         {
             return NotFound("Company not found");
         }
    
         var companyResource = mapper.Map<Company, CompanyDTO>(company);
         return Ok(companyResource); // This should return a JSON response
     }

     [HttpPost]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<CompanyDTO>> CreateCompany([FromBody] UpdateCompanyDTO saveCompanyResource)
     {
         var companyToCreate = mapper.Map<UpdateCompanyDTO, Company>(saveCompanyResource);

         var newCompany = await companyService.CreateEntityAsync(companyToCreate);

         var company = await companyService.GetEntityByIdAsync(newCompany.CompanyId);

         var companyResource = mapper.Map<Company, CompanyDTO>(company);
         return Ok(companyResource);
     }

     [HttpDelete]
     // [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteCompany(int id)
     {
         if (id == 0)
             return BadRequest();

         var company = await companyService.GetEntityByIdAsync(id);

         if (company == null)
             return NotFound();

         await companyService.DeleteEntityAsync(company);

         return NoContent();
     }
    

     [HttpPut]
     // [Authorize(Roles = "Admin,Founder")]
     public async Task<ActionResult<CompanyDTO>> UpdateCompany(int id, [FromBody]UpdateCompanyDTO saveCompanyResource)
     {
         var companyToBeUpdated = await companyService.GetEntityByIdAsync(id);

         if (companyToBeUpdated == null)
             return NotFound();

         var company = mapper.Map<UpdateCompanyDTO, Company>(saveCompanyResource);

         await companyService.UpdateEntityAsync(companyToBeUpdated, company);

         var updatedCompany = await companyService.GetEntityByIdAsync(id);
         var updatedCompanyResource = mapper.Map<Company, CompanyDTO>(updatedCompany);
         return Ok(updatedCompanyResource);
     }
     
     [HttpGet("{id}")]
     public async Task<ActionResult<string>> GetCompanyNameById(int id)
     {
         var company = await companyService.GetEntityByIdAsync(id);
         if (company == null)
         {
             return NotFound("Company not found");
         }
         return Ok(company.Name); // Assuming 'Name' is a property of the Company model
     }
}