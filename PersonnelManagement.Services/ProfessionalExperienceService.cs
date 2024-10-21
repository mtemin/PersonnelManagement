using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public class ProfessionalExperienceService:BaseService<ProfessionalExperience>
{
    public ProfessionalExperienceService(IUnitOfWork unitOfWork, IRepository<ProfessionalExperience> repository) : base(unitOfWork, repository)
    {
    }
}