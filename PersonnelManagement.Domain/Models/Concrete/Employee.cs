using PersonnelManagement.Domain.Models.Abstract;

namespace PersonnelManagement.Domain.Models.Concrete;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Title { get; set; }
    public Company Company { get; set; }
    public int CompanyId { get; set; }
    public ICollection<LeaveDay> LeaveDays { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<Education> Educations { get; set; }
    public ICollection<Certificate> Certificates { get; set; }
    public ICollection<ProfessionalExperience> ProfessionalExperiences { get; set; }
}