using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class CompanyService : BaseService<Company>,ICompanyService
{
    private readonly IUnitOfWork unitOfWork;
    

    public CompanyService(IUnitOfWork _unitOfWork, IRepository<Company> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<Company> UpdateEntityAsync(Company companyToBeUpdated, Company company)
    {
        companyToBeUpdated.Name = company.Name;
        await unitOfWork.CommitAsync();
        return await unitOfWork.Companies.GetByIdAsync(company.CompanyId);
    }

}