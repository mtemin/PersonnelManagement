using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Repositories;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllWithEmployeeAsync();
    Task<Company> GetWithEmployeeAsync(int id);
}