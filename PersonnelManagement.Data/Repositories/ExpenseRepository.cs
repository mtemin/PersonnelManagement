using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Data.Repositories;

public class ExpenseRepository:Repository<Expense>,IExpenseRepository
{
    public ExpenseRepository(PersonnelManagementDbContext context):base(context)
    {

    }
    private PersonnelManagementDbContext PersonnelManagementDbContext
    {
        get { return context as PersonnelManagementDbContext; }
    }
}