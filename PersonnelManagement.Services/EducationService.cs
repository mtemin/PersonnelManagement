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

    public async Task<Education> UpdateEntityAsync(Education educationToBeUpdated, Education education)
    {
        educationToBeUpdated.Degree = education.Degree;
        educationToBeUpdated.EmployeeId = education.EmployeeId;
        educationToBeUpdated.SchoolName = education.SchoolName;
        educationToBeUpdated.FieldOfStudy = education.FieldOfStudy;
        educationToBeUpdated.Description = education.Description;
        educationToBeUpdated.StartDate = education.StartDate;
        educationToBeUpdated.EndDate = education.EndDate;
                
        await unitOfWork.CommitAsync();
        return await unitOfWork.Educations.GetByIdAsync(education.EducationId);
    }

    public async Task<IEnumerable<Education>> GetEducationByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.Educations.Find(edc => edc.EmployeeId == employeeId);
    }
    
}