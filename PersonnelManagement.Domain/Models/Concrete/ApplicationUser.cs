using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Domain.Models.Concrete;

public class ApplicationUser  : IdentityUser<string>
{
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}