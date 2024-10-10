using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Services;

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
     public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAllCompanies()
     {
         var companies = await companyService.GetAllEntitiesAsync();
         var companiesResources = mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDTO>>(companies);

         return Ok(companiesResources);
     }

     [HttpGet("id")]
     public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
     {
         var company = await companyService.GetEntityByIdAsync(id);
         var companyResource = mapper.Map<Company, CompanyDTO>(company);
         return Ok(companyResource);
     }

     [HttpPost]
     public async Task<ActionResult<CompanyDTO>> CreateCompany([FromBody] UpdateCompanyDTO saveCompanyResource)
     {
         // var validator = new SaveCompanyResourceValidator();
         // var validationResult = await validator.ValidateAsync(saveCompanyResource);
         //
         // if (!validationResult.IsValid)
         //     return BadRequest(validationResult.Errors);

         var companyToCreate = mapper.Map<UpdateCompanyDTO, Company>(saveCompanyResource);

         var newCompany = await companyService.CreateEntityAsync(companyToCreate);

         var company = await companyService.GetEntityByIdAsync(newCompany.CompanyId);

         var companyResource = mapper.Map<Company, CompanyDTO>(company);
         return Ok(companyResource);
     }

     [HttpDelete]
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

     // [HttpDelete]
     // public async Task<ActionResult<CompanyDTO>> DeleteCompany(int id)
     // {
     //     if (id == 0)
     //         return BadRequest();
     //
     //     var company = await companyService.GetCompanyById(id);
     //
     //     if (company == null)
     //         return NotFound();
     //
     //     await companyService.DeleteCompany(company);
     //
     //     var companyResource = mapper.Map<Company, CompanyDTO>(company);
     //
     //     return Ok(companyResource);
     // }

     [HttpPut]
     public async Task<ActionResult<CompanyDTO>> UpdateCompany(int id, [FromBody]UpdateCompanyDTO saveCompanyResource)
     {
         // var validator = new SaveCompanyResourceValidator();
         // var validationResult = await validator.ValidateAsync(saveCompanyResource);
         //
         // var requestIsInvalid = id == 0 || !validationResult.IsValid;
         //
         // if (requestIsInvalid)
         //     return BadRequest(validationResult.Errors);

         var companyToBeUpdated = await companyService.GetEntityByIdAsync(id);

         if (companyToBeUpdated == null)
             return NotFound();

         var company = mapper.Map<UpdateCompanyDTO, Company>(saveCompanyResource);

         await companyService.UpdateEntityAsync(companyToBeUpdated, company);

         var updatedCompany = await companyService.GetEntityByIdAsync(id);
         var updatedCompanyResource = mapper.Map<Company, CompanyDTO>(updatedCompany);
         return Ok(updatedCompanyResource);
     }
}