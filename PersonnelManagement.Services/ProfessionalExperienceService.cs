using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class ProfessionalExperienceService:BaseService<ProfessionalExperience>, IProfessionalExperienceService
{
    private readonly IUnitOfWork unitOfWork;

    public ProfessionalExperienceService(IUnitOfWork _unitOfWork, IRepository<ProfessionalExperience> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<ProfessionalExperience> UpdateEntityAsync(ProfessionalExperience professionalExperienceToBeUpdated,
        ProfessionalExperience professionalExperience)
    {
        professionalExperienceToBeUpdated.Company = professionalExperience.Company;
        professionalExperienceToBeUpdated.JobTitle = professionalExperience.JobTitle;
                
        await unitOfWork.CommitAsync();
        return await unitOfWork.ProfessionalExperiences.GetByIdAsync(professionalExperience.ProfessionalExperienceId);
    }

    public async Task<IEnumerable<ProfessionalExperience>> GetProfessionalExperiencesByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.ProfessionalExperiences.Find(pe => pe.EmployeeId == employeeId);
    }
}