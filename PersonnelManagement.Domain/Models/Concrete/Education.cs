using System.ComponentModel.DataAnnotations;

namespace PersonnelManagement.Data.Model.Abstract;

public class Education:Experience
{
    [Required]
    public int EducationId { get; set; }
    [Required]
    public string Degree { get; set; }
    public string? FieldOfStudy { get; set; }
}