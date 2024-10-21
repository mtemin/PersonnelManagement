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


}