using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Services;

public interface IProfessionalExperienceService:IService<ProfessionalExperience>
{
    Task<ProfessionalExperience> UpdateEntityAsync(ProfessionalExperience professionalExperienceToBeUpdated, ProfessionalExperience professionalExperience);
    Task<IEnumerable<ProfessionalExperience>> ProfessionalExperiencesByEmployeeIdAsync(int professionalExperienceId);


}