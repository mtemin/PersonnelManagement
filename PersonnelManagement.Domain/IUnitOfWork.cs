
using PersonnelManagement.Domain.Models;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Domain;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
    ICompanyRepository Companies { get; }
    IEmployeeRepository Employees { get; }
    IExpenseRepository Expenses { get; }
    ILeaveDayRepository LeaveDays { get; }
    IEducationRepository Educations { get; }
    ICertificateRepository Certificates { get; }
    IProfessionalExperienceRepository ProfessionalExperiences { get; }
}