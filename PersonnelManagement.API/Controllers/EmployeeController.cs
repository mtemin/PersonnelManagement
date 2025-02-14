﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Services;
using System.Xml;

namespace PersonnelManagement.API.Controllers;

 [Route("[action]")]
 [ApiController]
 public class EmployeeController : ControllerBase
 {

     private readonly IEmployeeService employeeService;
     private readonly IMapper mapper;

     public EmployeeController(IEmployeeService service, IMapper _mapper)
     {
         this.employeeService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
     {
         var employees = await employeeService.GetAllEntitiesAsync();
         var employeesResources = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);

         return Ok(employeesResources);
     }

     [HttpGet( "{id}")]
     public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
     {
         var employee = await employeeService.GetEntityByIdAsync(id);
         var employeeResource = mapper.Map<Employee, EmployeeDTO>(employee);
         return Ok(employeeResource);
     }

     [HttpPost]
     public async Task<ActionResult<EmployeeDTO>> CreateEmployee([FromBody] UpdateEmployeeDTO saveEmployeeResource)
     {
         var employeeToCreate = mapper.Map<UpdateEmployeeDTO, Employee>(saveEmployeeResource);

         var newEmployee = await employeeService.CreateEntityAsync(employeeToCreate);

         var employee = await employeeService.GetEntityByIdAsync(newEmployee.EmployeeId);

         var employeeResource = mapper.Map<Employee, EmployeeDTO>(employee);
         return Ok(employeeResource);
     }

     [HttpDelete]
     public async Task<IActionResult> DeleteEmployee(int id)
     {
         if (id == 0)
             return BadRequest();

         var employee = await employeeService.GetEntityByIdAsync(id);

         if (employee == null)
             return NotFound();

         await employeeService.DeleteEntityAsync(employee);

         return NoContent();
     }

     [HttpPut]
     public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(int id, [FromBody]UpdateEmployeeDTO saveEmployeeResource)
     {


         var employeeToBeUpdated = await employeeService.GetEntityByIdAsync(id);

         if (employeeToBeUpdated == null)
             return NotFound();

         var employee = mapper.Map<UpdateEmployeeDTO, Employee>(saveEmployeeResource);

         await employeeService.UpdateEntityAsync(employeeToBeUpdated, employee);

         var updatedEmployee = await employeeService.GetEntityByIdAsync(id);
         var updatedEmployeeResource = mapper.Map<Employee, EmployeeDTO>(updatedEmployee);
         return Ok(updatedEmployeeResource);
     }
     
     [HttpGet("{id}")]
     public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByCompanyId(int id)
     {
         var employees = await employeeService.GetEmployeesByCompanyIdAsync(id);
    
         if (employees == null || !employees.Any())
         {
             return Ok(new List<EmployeeDTO>());

         }

         var employeeResources = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
    
         return Ok(employeeResources);
     }
 }