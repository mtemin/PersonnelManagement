using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Repositories;
using PersonnelManagement.Domain.Services;

namespace PersonnelManagement.Services;

public class LeaveDayService:BaseService<LeaveDay>, ILeaveDayService
{
    private readonly IUnitOfWork unitOfWork;

    public LeaveDayService(IUnitOfWork _unitOfWork, IRepository<LeaveDay> repository)
        : base(_unitOfWork, repository)
    {
        unitOfWork = _unitOfWork;
    }

    public Task<LeaveDay> UpdateEntityAsync(LeaveDay leaveDayToBeUpdated, LeaveDay leaveDay)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<LeaveDay>> GetLeaveDaysByCompanyIdAsync(int companyId)
    {
        return unitOfWork.LeaveDays.Find(e => e.CompanyId == companyId);
    }
    
    public async Task<IEnumerable<LeaveDay>> GetLeaveDaysByEmployeeIdAsync(int employeeId)
    {
        return unitOfWork.LeaveDays.Find(e => e.EmployeeId == employeeId);
    }
}