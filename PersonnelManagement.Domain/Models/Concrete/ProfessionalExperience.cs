using System.ComponentModel.DataAnnotations;
using PersonnelManagement.Data.Model.Abstract;

namespace PersonnelManagement.Data.Model.Concrete;

public class ProfessionalExperience:Experience
{
    [Required]
    public int ProfessionalExperienceId { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    public string JobTitle { get; set; }
}