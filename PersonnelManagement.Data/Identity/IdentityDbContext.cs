using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Data.Identity;

public class IdentityDbContext : IdentityDbContext<IdentityUser>
{
    //Identity
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
        
    }
}