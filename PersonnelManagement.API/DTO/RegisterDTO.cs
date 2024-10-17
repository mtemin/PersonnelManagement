using System.ComponentModel.DataAnnotations;

namespace PersonnelManagement.API.DTO;

public class RegisterDTO
{
    [Required]
    [StringLength(maximumLength:50,ErrorMessage = "The {propertyName} must be at least {minimumLength} characters long.", MinimumLength = 4)]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The {propertyName} must be at least {minimumLength} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}