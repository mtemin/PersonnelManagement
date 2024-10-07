using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;


namespace PersonnelManagement.Domain.Models.Concrete;

public class Company
{
    [Required]
    public int CompanyId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public List<Employee>Employees { get; set; }
    [Required]
    public List<Expense> Expenses { get; set; }
    [Required]
    public List<LeaveDay> PersonnelLeaveDays { get; set; }
    
}