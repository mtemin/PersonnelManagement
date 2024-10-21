using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public class EducationService:BaseService<Education>
{
    public EducationService(IUnitOfWork unitOfWork, IRepository<Education> repository) : base(unitOfWork, repository)
    {
    }
}