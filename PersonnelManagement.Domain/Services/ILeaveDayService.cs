using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Services;

public interface ILeaveDayService:IService<LeaveDay>
{
    Task<LeaveDay> UpdateEntityAsync(LeaveDay leaveDayToBeUpdated, LeaveDay leaveDay);
    Task<IEnumerable<LeaveDay>> GetLeaveDaysByCompanyIdAsync(int companyId);
    Task<IEnumerable<LeaveDay>> GetLeaveDaysByEmployeeIdAsync(int employeeId);


}