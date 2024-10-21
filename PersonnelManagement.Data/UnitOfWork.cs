using PersonnelManagement.Data.Repositories;
using PersonnelManagement.Domain;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Models.Concrete;
using PersonnelManagement.Domain.Repositories;

namespace PersonnelManagement.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly PersonnelManagementDbContext context;
    private CompanyRepository companyRepository;
    private EmployeeRepository employeeRepository;

    public UnitOfWork(PersonnelManagementDbContext _context)
    {
        this.context = _context;
    }
    
    
    public IExpenseRepository Expenses { get; }
    public ILeaveDayRepository LeaveDays { get; }
    public IEducationRepository Educations { get; }
    public ICertificateRepository Certificates { get; }
    public IProfessionalExperienceRepository ProfessionalExperiences { get; }
    public ICompanyRepository Companies => companyRepository = companyRepository ?? new CompanyRepository(context); 
    public IEmployeeRepository Employees => employeeRepository = employeeRepository ?? new EmployeeRepository(context);

    public async Task<int> CommitAsync()
    {
        return await context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        context.Dispose();
    }
}