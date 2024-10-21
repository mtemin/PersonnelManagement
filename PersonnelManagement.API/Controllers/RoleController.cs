using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Controllers
{
    [Route("api/")]
    [ApiController]
    // [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager; 

        public RoleController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name cannot be empty.");
            }

            var role = new Role {Id=roleName, Name = roleName };
            var result = await _roleManager.CreateAsync(role);
    
            if (result.Succeeded)
            {
                return Ok($"Role {roleName} created successfully.");
            }

            return BadRequest($"Error creating role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
        
        [HttpDelete("delete/{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound($"Role {roleName} not found.");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok($"Role {roleName} deleted successfully.");
            }

            return BadRequest($"Error deleting role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
        
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
        
    }
}