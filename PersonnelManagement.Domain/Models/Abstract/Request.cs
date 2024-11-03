using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Domain.Models.Abstract;

public class Request
{

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