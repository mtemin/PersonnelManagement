namespace PersonnelManagement.API.DTO;

public class UpdateLeaveDayDTO
{
    public int EmployeeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsApproved { get; set; }
    public string Type { get; set; }
    public DateTime LeaveStartDay { get; set; }
    public DateTime LeaveEndDay { get; set; }
}