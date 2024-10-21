using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Domain.Models.Concrete;

public class Role : IdentityRole<string>
{
    public ICollection<UserRole> Users { get; set; } = new List<UserRole>();
}