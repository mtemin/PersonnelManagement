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
public class LeaveDayController:ControllerBase
{
     private readonly ILeaveDayService leaveDayService;
     private readonly IEmployeeService employeeService;
     private readonly IMapper mapper;

     public LeaveDayController(ILeaveDayService service, IEmployeeService _employeeService, IMapper _mapper)
     {
         this.employeeService = _employeeService;
         this.leaveDayService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<IEnumerable<LeaveDayDTO>>> GetAllLeaveDays()
     {
         var leavedays = await leaveDayService.GetAllEntitiesAsync();
         var leavedaysResources = mapper.Map<IEnumerable<LeaveDay>, IEnumerable<LeaveDayDTO>>(leavedays);

         return Ok(leavedaysResources);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<LeaveDayDTO>> GetLeaveDay(int id)
     {
         var leaveDay = await leaveDayService.GetEntityByIdAsync(id);
         if (leaveDay == null)
         {
             return NotFound("LeaveDay not found");
         }
    
         var leaveDayResource = mapper.Map<LeaveDay, LeaveDayDTO>(leaveDay);
         return Ok(leaveDayResource); // This should return a JSON response
     }

     [HttpPost]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<LeaveDayDTO>> CreateLeaveDay([FromBody] UpdateLeaveDayDTO saveLeaveDayResource)
     {
         var employee = await employeeService.GetEntityByIdAsync(saveLeaveDayResource.EmployeeId);
    
         if (employee == null)
         {
             return NotFound("Employee not found.");
         }
         var companyId = employee.CompanyId;
         var leaveDayToCreate = mapper.Map<UpdateLeaveDayDTO, LeaveDay>(saveLeaveDayResource);
         leaveDayToCreate.CompanyId = companyId;

         var newLeaveDay = await leaveDayService.CreateEntityAsync(leaveDayToCreate);

         var leaveDay = await leaveDayService.GetEntityByIdAsync(newLeaveDay.RequestId);

         var leaveDayResource = mapper.Map<LeaveDay, LeaveDayDTO>(leaveDay);
         return Ok(leaveDayResource);
     }

     [HttpDelete]
     // [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteLeaveDay(int id)
     {
         if (id == 0)
             return BadRequest();

         var leaveDay = await leaveDayService.GetEntityByIdAsync(id);

         if (leaveDay == null)
             return NotFound();

         await leaveDayService.DeleteEntityAsync(leaveDay);

         return NoContent();
     }
    

     [HttpPut]
     // [Authorize(Roles = "Admin,Founder")]
     public async Task<ActionResult<LeaveDayDTO>> UpdateLeaveDay(int id, [FromBody]UpdateLeaveDayDTO saveLeaveDayResource)
     {
         var leaveDayToBeUpdated = await leaveDayService.GetEntityByIdAsync(id);
     
         if (leaveDayToBeUpdated == null)
             return NotFound();
     
         var leaveDay = mapper.Map<UpdateLeaveDayDTO, LeaveDay>(saveLeaveDayResource);
     
         await leaveDayService.UpdateEntityAsync(leaveDayToBeUpdated, leaveDay);
     
         var updatedLeaveDay = await leaveDayService.GetEntityByIdAsync(id);
         var updatedLeaveDayResource = mapper.Map<LeaveDay, LeaveDayDTO>(updatedLeaveDay);
         return Ok(updatedLeaveDayResource);
     }
     
     
     [HttpGet("{id}")]
     public async Task<ActionResult<IEnumerable<LeaveDayDTO>>> GetLeaveDaysByEmployeeId(int companyId)
     {
         var leavedays = await leaveDayService.GetLeaveDaysByEmployeeIdAsync(companyId);
    
         if (leavedays == null || !leavedays.Any())
         {
             return NotFound("No leavedays found for the specified employee.");
         }

         var employeeResources = mapper.Map<IEnumerable<LeaveDay>, IEnumerable<LeaveDayDTO>>(leavedays);
    
         return Ok(employeeResources);
     }
     
}