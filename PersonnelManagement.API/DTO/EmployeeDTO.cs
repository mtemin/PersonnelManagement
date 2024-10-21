namespace PersonnelManagement.API.DTO;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Title { get; set; }
    public int CompanyId { get; set; }
    // public CompanyDTO Company { get; set; }
}
