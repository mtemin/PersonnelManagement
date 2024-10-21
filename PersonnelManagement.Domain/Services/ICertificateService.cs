using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Services;

public interface ICertificateService : IService<Certificate>
{
    Task<Employee> UpdateEntityAsync(Certificate educationToBeUpdated, Certificate education);
    Task<IEnumerable<Certificate>> GetCertificatesByEmployeeIdAsync(int employeeId);


    
}