using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class EducationService:BaseService<Education>, IEducationService
{
    private readonly IUnitOfWork unitOfWork;
    private IEducationService _educationServiceImplementation;

    public EducationService(IUnitOfWork _unitOfWork, IRepository<Education> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<Education>> GetEducationsByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.Educations.Find(e => e.EmployeeId == employeeId);
    }

    public Task<Employee> UpdateEntityAsync(Education educationToBeUpdated, Education education)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetEducationByEmployeeIdAsync(int employeeId)
    {
        throw new NotImplementedException();
    }
}