namespace PersonnelManagement.API.DTO;

public class ExpenseDTO
{
    public int RequestId { get; set; }
    public int EmployeeId { get; set; }
    public string Title { get; set; }
    public int CompanyId { get; set; }
    public string? Description { get; set; }
    public bool IsApproved { get; set; }
    public decimal Amount { get; set; }
}