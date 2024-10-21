using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonnelManagement.Domain;

namespace PersonnelManagement.Data.Identity;

public class RoleSeeder : IRoleSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<RoleSeeder> _logger;

    public RoleSeeder(RoleManager<IdentityRole> roleManager, ILogger<RoleSeeder> logger)
    {
        _roleManager = roleManager;
        _logger = logger;
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
        var roles = new[] { "Admin", "Founder", "Manager", "Employee" };
        foreach (var role in roles)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded)
            {
                _logger.LogInformation($"Role {role} created successfully.");
            }
            else
            {
                _logger.LogError($"Error creating role {role}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}