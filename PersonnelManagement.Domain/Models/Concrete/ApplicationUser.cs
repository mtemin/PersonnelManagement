using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Domain.Models.Concrete;

public class ApplicationUser  : IdentityUser<string>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string RoleId { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}