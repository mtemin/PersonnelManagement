using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Data.Configurations;
using PersonnelManagement.Domain.Models.Abstract;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Data;


public class PersonnelManagementDbContext : IdentityDbContext<ApplicationUser,Role, string>
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
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        
        modelBuilder.Entity<ApplicationUser >()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users) 
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
    
}