using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.API.DTO;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.API.Controllers;

// {
//     "username": "admin",
//     "email": "mteminn@gmail.com",
//     "password": "Admin*1",
//     "confirmPassword": "Admin*1"
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
        var user = new ApplicationUser  { UserName = dto.Username, Email = dto.Email};
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Employee");
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
    [HttpGet("users")]
    // [Authorize(Roles="Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = _userManager.Users.ToList();
        var userDtos = users.Select(user => new 
        {
            user.Id,
            user.UserName,
            user.Email
        }).ToList();

        return Ok(userDtos);
    }
}
