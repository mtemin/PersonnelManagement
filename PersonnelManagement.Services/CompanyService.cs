using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class CompanyService : BaseService<Company>,ICompanyService
{
    public CompanyService(IUnitOfWork unitOfWork, IRepository<Company> repository)
        : base(unitOfWork, repository)
    {
    }
}