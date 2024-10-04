using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Data.Model.Abstract;

namespace PersonnelManagement.Data.Model.Concrete;

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