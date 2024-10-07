using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetAllWithCompanyByCompanyIdAsync(int companyId);
    Task<IEnumerable<Employee>> GetAllWithCompanyAsync();
    Task<Employee> GetWithCompanyByIdAsync(int id);

}