using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Domain.Models.Concrete;

public class Role : IdentityRole<string>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<ApplicationUser> Users { get; set; }
}