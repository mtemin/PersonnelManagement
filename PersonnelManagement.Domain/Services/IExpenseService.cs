using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Services;

public interface IExpenseService:IService<Expense>
{
    Task<Expense> UpdateEntityAsync(Expense expenseToBeUpdated, Expense expense);
    Task<IEnumerable<Expense>> GetExpensesByCompanyIdAsync(int companyId);
    Task<IEnumerable<Expense>> GetExpensesByEmployeeIdAsync(int employeeId);


}