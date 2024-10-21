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
public class ExpenseController:ControllerBase
{
     private readonly IExpenseService expenseService;
     private readonly IMapper mapper;

     public ExpenseController(IExpenseService service, IMapper _mapper)
     {
         this.expenseService = service;
         this.mapper = _mapper;
     }

     [HttpGet]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetAllExpenses()
     {
         var expense = await expenseService.GetAllEntitiesAsync();
         var expenseResources = mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expense);

         return Ok(expenseResources);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<ExpenseDTO>> GetExpense(int id)
     {
         var expense = await expenseService.GetEntityByIdAsync(id);
         if (expense == null)
         {
             return NotFound("Expense not found");
         }
    
         var expenseResource = mapper.Map<Expense, ExpenseDTO>(expense);
         return Ok(expenseResource); // This should return a JSON response
     }

     [HttpPost]
     // [Authorize(Roles = "Admin")]
     public async Task<ActionResult<ExpenseDTO>> CreateExpense([FromBody] UpdateExpenseDTO saveExpenseResource)
     {
         var expenseToCreate = mapper.Map<UpdateExpenseDTO, Expense>(saveExpenseResource);

         var newExpense = await expenseService.CreateEntityAsync(expenseToCreate);

         var expense = await expenseService.GetEntityByIdAsync(newExpense.RequestId);

         var expenseResource = mapper.Map<Expense, ExpenseDTO>(expense);
         return Ok(expenseResource);
     }

     [HttpDelete]
     // [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteExpense(int id)
     {
         if (id == 0)
             return BadRequest();

         var expense = await expenseService.GetEntityByIdAsync(id);

         if (expense == null)
             return NotFound();

         await expenseService.DeleteEntityAsync(expense);

         return NoContent();
     }
    

     [HttpPut]
     // [Authorize(Roles = "Admin,Founder")]
     public async Task<ActionResult<ExpenseDTO>> UpdateExpense(int id, [FromBody]UpdateExpenseDTO saveExpenseResource)
     {
         var expenseToBeUpdated = await expenseService.GetEntityByIdAsync(id);
     
         if (expenseToBeUpdated == null)
             return NotFound();
     
         var expense = mapper.Map<UpdateExpenseDTO, Expense>(saveExpenseResource);
     
         await expenseService.UpdateEntityAsync(expenseToBeUpdated, expense);
     
         var updatedExpense = await expenseService.GetEntityByIdAsync(id);
         var updatedExpenseResource = mapper.Map<Expense, ExpenseDTO>(updatedExpense);
         return Ok(updatedExpenseResource);
     }
     
     [HttpGet("{id}")]    
     public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetExpensesByEmployeeId(int companyId)
     {
         var expenses = await expenseService.GetExpensesByEmployeeIdAsync(companyId);
    
         if (expenses == null || !expenses.Any())
         {
             return NotFound("No expenses found for the specified employee.");
         }

         var employeeResources = mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
    
         return Ok(employeeResources);
     }
     
}