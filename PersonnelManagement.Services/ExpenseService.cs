using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class ExpenseService:BaseService<Expense>, IExpenseService
{
    private readonly IUnitOfWork unitOfWork;

    public ExpenseService(IUnitOfWork _unitOfWork, IRepository<Expense> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<Expense> UpdateEntityAsync(Expense expenseToBeUpdated, Expense expense)
    {
        expenseToBeUpdated.Amount = expense.Amount;
        expenseToBeUpdated.EmployeeId = expense.EmployeeId;
        expenseToBeUpdated.Title = expense.Title;
        expenseToBeUpdated.CompanyId = expense.CompanyId;
        expenseToBeUpdated.Description = expense.Description;
        expenseToBeUpdated.IsApproved = expense.IsApproved;
                
        await unitOfWork.CommitAsync();
        return await unitOfWork.Expenses.GetByIdAsync(expense.ExpenseId);
    }

    public async Task<IEnumerable<Expense>> GetExpensesByCompanyIdAsync(int companyId)
    {
        return unitOfWork.Expenses.Find(e => e.CompanyId == companyId);
    }
    
    public async Task<IEnumerable<Expense>> GetExpensesByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.Expenses.Find(e => e.EmployeeId == employeeId);
    }
    
}