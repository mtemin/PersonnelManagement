using PersonnelManagement.Data.Model.Concrete;

namespace PersonnelManagement.Domain.Repository;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllWithEmployeeAsync();
    Task<Company> GetWithEmployeeAsync(int id);
}