namespace PersonnelManagement.API.DTO;

public class LeaveDayDTO
{
    public int LeaveDayId { get; set; }
    public int EmployeeId { get; set; }
    public string Title { get; set; }
    public int CompanyId { get; set; }
    public string Description { get; set; }
    public bool IsApproved { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}