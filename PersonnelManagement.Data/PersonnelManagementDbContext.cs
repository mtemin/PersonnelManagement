using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(ur => ur.RoleId);
        
    }
    
}