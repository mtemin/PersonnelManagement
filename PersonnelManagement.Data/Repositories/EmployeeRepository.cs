using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Data.Repositories;

public class EmployeeRepository : Repository<Employee>,IEmployeeRepository
{
    public EmployeeRepository(PersonnelManagementDbContext context) : base(context)
    {
        
    }

    private PersonnelManagementDbContext PersonnelManagementDbContext
    {
        get {return context as PersonnelManagementDbContext;}
    }


    public async Task<IEnumerable<Employee>> GetAllWithCompanyByCompanyIdAsync(int companyId)
    {
        return await PersonnelManagementDbContext.Employees
            .Include(x => x.Company)
            .Where(x => x.CompanyId == companyId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetAllWithCompanyAsync()
    {
        return await PersonnelManagementDbContext.Employees
            .Include(x => x.Company)
            .ToListAsync();
    }

    public async Task<Employee> GetWithCompanyByIdAsync(int id)
    {
        return await PersonnelManagementDbContext.Employees
            .Include(x => x.Company)
            .SingleOrDefaultAsync(x => x.EmployeeId == id);
    }
}