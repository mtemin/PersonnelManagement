using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllWithCompany();
    Task<Employee> GetEmployeeById(int id);
    Task<IEnumerable<Employee>> GetEmployeeByCompanyId(int companyId);
    Task<Employee> CreateEmployee(Employee newEmployee);
    Task<Employee> UpdateEmployee(Employee employeeToBeUpdated, Employee employee);
    //Task<Employee> UpdateEmployee(int employeeId, Employee employee);
    Task<Employee> DeleteEmployee(int employeeId);
}