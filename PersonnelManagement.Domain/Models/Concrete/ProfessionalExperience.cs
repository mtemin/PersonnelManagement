using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class ProfessionalExperience:Experience
{
    [Required]
    public int ProfessionalExperienceId { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    public string JobTitle { get; set; }
}