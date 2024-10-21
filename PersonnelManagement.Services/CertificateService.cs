using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public class CertificateService:BaseService<Certificate>
{
    public CertificateService(IUnitOfWork unitOfWork, IRepository<Certificate> repository) : base(unitOfWork, repository)
    {
    }
}