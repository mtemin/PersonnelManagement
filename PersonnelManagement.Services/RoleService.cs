using Microsoft.AspNetCore.Identity;

namespace PersonnelManagement.Services;

public class RoleService
{
    private readonly UserManager<IdentityUser> _userManager;

    public RoleService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task AssignRoleToUser(IdentityUser user, string roleName)
    {
        await _userManager.AddToRoleAsync(user, roleName);
    }
}