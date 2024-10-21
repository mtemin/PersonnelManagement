namespace PersonnelManagement.Domain.Models.Concrete;

public class UserRole
{
    public string UserId { get; set; }
    public ApplicationUser  User { get; set; }

    public string RoleId { get; set; }
    public Role Role { get; set; }
}