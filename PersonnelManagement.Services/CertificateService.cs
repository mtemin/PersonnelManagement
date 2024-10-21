using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class CertificateService:BaseService<Certificate>, ICertificateService
{
    private readonly IUnitOfWork unitOfWork;

    public CertificateService(IUnitOfWork _unitOfWork, IRepository<Certificate> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public async Task<IEnumerable<Certificate>> GetCertificatesByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.Certificates.Find(e => e.EmployeeId == employeeId);
    }

    public Task<Employee> UpdateEntityAsync(Certificate educationToBeUpdated, Certificate education)
    {
        throw new NotImplementedException();
    }


}