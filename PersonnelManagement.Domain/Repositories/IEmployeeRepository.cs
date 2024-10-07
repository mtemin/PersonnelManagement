using PersonnelManagement.Data.Model.Concrete;

namespace PersonnelManagement.Domain.Repository;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetAllWithCompanyByCompanyIdAsync(int companyId);
    Task<IEnumerable<Employee>> GetAllWithCompanyAsync();
    Task<Employee> GetWithCompanyByIdAsync(int id);

}