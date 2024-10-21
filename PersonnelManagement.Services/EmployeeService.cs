using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class EmployeeService : BaseService<Employee>, IEmployeeService
{
    private readonly IUnitOfWork unitOfWork;
    

    public EmployeeService(IUnitOfWork _unitOfWork, IRepository<Employee> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<Employee> UpdateEntityAsync(Employee employeeToBeUpdated, Employee employee)
    {
        employeeToBeUpdated.Name = employee.Name;
        employeeToBeUpdated.Surname = employee.Surname;
        employeeToBeUpdated.Title = employee.Title;
        employeeToBeUpdated.CompanyId = employee.CompanyId;
        employeeToBeUpdated.Company = employee.Company;
        employeeToBeUpdated.Certificates = employee.Certificates;
        employeeToBeUpdated.Educations = employee.Educations;
        employeeToBeUpdated.Expenses = employee.Expenses;
        employeeToBeUpdated.LeaveDays = employee.LeaveDays;
        employeeToBeUpdated.ProfessionalExperiences = employee.ProfessionalExperiences;
        
        await unitOfWork.CommitAsync();
        return await unitOfWork.Employees.GetByIdAsync(employee.EmployeeId);
    }
    
    public async Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        return unitOfWork.Employees.Find(e => e.CompanyId == companyId);
    }
}