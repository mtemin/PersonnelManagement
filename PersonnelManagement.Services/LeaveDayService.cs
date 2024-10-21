using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Services;

public class LeaveDayService:BaseService<LeaveDay>
{
    public LeaveDayService(IUnitOfWork unitOfWork, IRepository<LeaveDay> repository) : base(unitOfWork, repository)
    {
    }
}