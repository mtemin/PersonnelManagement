
using PersonnelManagement.Domain.Models;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Domain;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    ICompanyRepository Companies { get; }
    IRepository<Certificate> Certificates { get; }
    IRepository<LeaveDay> LeaveDays { get; }
    IRepository<ProfessionalExperience> ProfessionalExperiences { get; }
    IRepository<Expense> Expenses { get; }
    Task<int> CommitAsync();
}