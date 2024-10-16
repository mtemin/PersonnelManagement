using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Domain.Services;

public interface IRoleService
{
    Task AssignRoleToUserAsync(IdentityUser  user, string roleName);
    Task RemoveRoleFromUserAsync(IdentityUser  user, string roleName);
    // Add more methods as needed
}