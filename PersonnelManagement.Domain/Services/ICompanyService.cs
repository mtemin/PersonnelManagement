using PersonnelManagement.Data.Model.Concrete;

namespace PersonnelManagement.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAllCompanies();
    Task<Company> GetCompanyById(int id);
    Task<Company> CreateCompany(Company newCompany);
    Task UpdateCompany(Company companyToBeUpdated, Company company);
    Task DeleteCompany(Company company); 
}