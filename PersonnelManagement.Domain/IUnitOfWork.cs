
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
    IRepository<Expense> Expenses { get; } //employee, company
    IRepository<LeaveDay> LeaveDays { get; } //employee, company
    IRepository<Education> Educations { get; } //employee
    IRepository<Certificate> Certificates { get; } //employee
    IRepository<ProfessionalExperience> ProfessionalExperiences { get; } //employee
}