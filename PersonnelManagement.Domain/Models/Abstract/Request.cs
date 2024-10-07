using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Models.Abstract;

public class Request
{
    //base class for expense and leave days
    [Key]
    public int RequestId { get; set; }
    [Required]
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
    [Required]
    public string Title { get; set; }
    public Company Company { get; set; }
    public int CompanyId { get; set; }
    public string? Description { get; set; }
    [Required]
    public bool IsApproved { get; set; }

}