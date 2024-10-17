using Microsoft.AspNetCore.Identity;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Services;

public class RoleService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task AssignRoleToUser(ApplicationUser user, string roleName)
    {
        await _userManager.AddToRoleAsync(user, roleName);
    }
}