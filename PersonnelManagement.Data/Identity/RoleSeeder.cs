using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PersonnelManagement.Data.Identity;

public class RoleSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleSeeder(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {
        if (!(await _roleManager.Roles.AnyAsync()))
        {
            await CreateRoles();
        }
    }

    private async Task CreateRoles()
    {
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        await _roleManager.CreateAsync(new IdentityRole("Founder"));
        await _roleManager.CreateAsync(new IdentityRole("Manager"));
        await _roleManager.CreateAsync(new IdentityRole("Employee"));
    }
}