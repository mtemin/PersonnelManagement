using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public class ProfessionalExperienceService:BaseService<ProfessionalExperience>
{
    private readonly IUnitOfWork unitOfWork;

    public ProfessionalExperienceService(IUnitOfWork _unitOfWork, IRepository<ProfessionalExperience> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<ProfessionalExperience>> ProfessionalExperiencesByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.ProfessionalExperiences.Find(e => e.EmployeeId == employeeId);
    }
}