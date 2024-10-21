using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Abstract;
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

    public Task<Expense> UpdateEntityAsync(Expense expenseToBeUpdated, Expense expense)
    {
        throw new NotImplementedException();
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