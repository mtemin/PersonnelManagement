using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.API.Controllers;

// {
//     "username": "admin",
//     "email": "mteminn@gmail.com",
//     "password": "admin",
//     "confirmPassword": "admin"
// }

[ApiController]
[Route("api/")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser > _userManager;
    private readonly SignInManager<ApplicationUser > _signInManager;

    public UsersController(UserManager<ApplicationUser > userManager, SignInManager<ApplicationUser > signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
        // Create a new user and assign to a role
        var user = new ApplicationUser  { UserName = dto.Username, Email = dto.Email };
        // user.Id = Guid.NewGuid().ToString();
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Employee"); // Assign to a role
            return Ok("User  created successfully");
        }
        return BadRequest("Failed to create user");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, lockoutOnFailure: true);
        if (result.Succeeded)
        {
            return Ok("Logged in successfully");
        }
        else
        {
        return Unauthorized("Invalid username or password");
        }
    }
}