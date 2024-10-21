using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public class ExpenseService:BaseService<Expense>
{
    public ExpenseService(IUnitOfWork unitOfWork, IRepository<Expense> repository) : base(unitOfWork, repository)
    {
    }  
}