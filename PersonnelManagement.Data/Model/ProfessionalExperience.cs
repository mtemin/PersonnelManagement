namespace PersonnelManagement.Data.Model;

public class ProfessionalExperience
{
    public int ProfessionalExperienceId { get; set; }
    public string CompanyName { get; set; }
    public string Title { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    
}