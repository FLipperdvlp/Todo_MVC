using System.ComponentModel.DataAnnotations;

namespace Todos.Models.Login;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [MinLength(6, ErrorMessage = "minimum length is 6")]
    public string Password { get; set; } = string.Empty;
}