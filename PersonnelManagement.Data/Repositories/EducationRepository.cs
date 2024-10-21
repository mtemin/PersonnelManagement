using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Data.Repositories;

public class EducationRepository:Repository<Education>,IEducationRepository
{
    public EducationRepository(PersonnelManagementDbContext context):base(context)
    {

    }
    private PersonnelManagementDbContext PersonnelManagementDbContext
    {
        get { return context as PersonnelManagementDbContext; }
    }
}