using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Concrete;
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

    public async Task<LeaveDay> UpdateEntityAsync(LeaveDay leaveDayToBeUpdated, LeaveDay leaveDay)
    {
        leaveDayToBeUpdated.EmployeeId = leaveDay.EmployeeId;
        leaveDayToBeUpdated.CompanyId = leaveDay.CompanyId;
        leaveDayToBeUpdated.Description = leaveDay.Description;
        leaveDayToBeUpdated.IsApproved = leaveDay.IsApproved;
        leaveDayToBeUpdated.Title = leaveDay.Title;
        leaveDayToBeUpdated.Type = leaveDay.Type;
        leaveDayToBeUpdated.StartDate = leaveDay.StartDate;
        leaveDayToBeUpdated.EndDate = leaveDay.EndDate;
        
        await unitOfWork.CommitAsync();
        return await unitOfWork.LeaveDays.GetByIdAsync(leaveDay.LeaveDayId);
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