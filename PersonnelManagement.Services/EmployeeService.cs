using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class EmployeeService : BaseService<Employee>
{
    public EmployeeService(IUnitOfWork unitOfWork, IRepository<Employee> repository)
        : base(unitOfWork, repository)
    {
    }
}