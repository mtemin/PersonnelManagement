using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PersonnelManagement.Data.Model.Concrete;

namespace PersonnelManagement.Data.Model.Abstract;

public class Experience
{
    //base class for education,certificates and professional experience
    [Required]
    public int ExperienceId { get; set; }
    [Required]
    public Employee Employee { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly EndDate { get; set; }
}

