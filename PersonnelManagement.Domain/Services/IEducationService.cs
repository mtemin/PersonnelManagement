using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Services;

public interface IEducationService:IService<Education>
{
    Task<Employee> UpdateEntityAsync(Education educationToBeUpdated, Education education);
    Task<IEnumerable<Education>> GetEducationsByEmployeeIdAsync(int employeeId);


}