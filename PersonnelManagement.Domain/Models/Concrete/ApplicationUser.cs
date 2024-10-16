using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Domain.Models.Concrete;

public class ApplicationUser  : IdentityUser<string>
{
    public string RoleId { get; set; }
    public Role Role { get; set; }
}