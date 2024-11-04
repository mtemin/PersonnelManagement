using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class Education:Experience
{
    [Required]
    public int EducationId { get; set; }
    public string SchoolName { get; set; }
    [Required]
    public string Degree { get; set; }
    public string? FieldOfStudy { get; set; }
}