using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Data.Configurations;
using PersonnelManagement.Data.Model;
using PersonnelManagement.Data.Model.Abstract;
using PersonnelManagement.Data.Model.Concrete;

namespace PersonnelManagement.Data;

public class PersonnelManagementDbContext : DbContext
{

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees {  get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<LeaveDay> LeaveDays { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }
    
    public PersonnelManagementDbContext(DbContextOptions<PersonnelManagementDbContext> options) : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());


    }
    
}