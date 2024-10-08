using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Data.Repositories;

public class CompanyRepository:Repository<Company>,ICompanyRepository
{
    public CompanyRepository(PersonnelManagementDbContext context):base(context)
    {

    }

    private PersonnelManagementDbContext PersonnelManagementDbContext
    {
        get { return context as PersonnelManagementDbContext; }
    }

    public async Task<IEnumerable<Company>> GetAllWithEmployeeAsync()
    {
        return await PersonnelManagementDbContext.Companies
            .Include(x=>x.Employees)
            .ToListAsync();
    }

    public async Task<Company> GetWithEmployeeAsync(int id)
    {
        return await PersonnelManagementDbContext.Companies
            .Include(x => x.Employees)
            .SingleOrDefaultAsync(x => x.CompanyId == id);
    }
}