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
    
    private ExpenseRepository expenseRepository;
    private LeaveDayRepository leaveDayRepository;
    private EducationRepository educationRepository;
    private CertificateRepository certificateRepository;
    private ProfessionalExperienceRepository professionalExperienceRepository;

    public UnitOfWork(PersonnelManagementDbContext _context)
    {
        this.context = _context;
    }
    
    public ICompanyRepository Companies => companyRepository = companyRepository ?? new CompanyRepository(context); 
    public IEmployeeRepository Employees => employeeRepository = employeeRepository ?? new EmployeeRepository(context);
    public IExpenseRepository Expenses => expenseRepository = expenseRepository ?? new ExpenseRepository(context); 
    public ILeaveDayRepository LeaveDays => leaveDayRepository = leaveDayRepository ?? new LeaveDayRepository(context); 
    public IEducationRepository Educations => educationRepository = educationRepository ?? new EducationRepository(context);
    public ICertificateRepository Certificates => certificateRepository = certificateRepository ?? new CertificateRepository(context);
    public IProfessionalExperienceRepository ProfessionalExperiences => professionalExperienceRepository = professionalExperienceRepository ?? new ProfessionalExperienceRepository(context);

    public async Task<int> CommitAsync()
    {
        return await context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        context.Dispose();
    }
}