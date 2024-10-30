using System.ComponentModel.DataAnnotations;


namespace OnlineFoodOrderingSystem.Models.Identity;

public class Login
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    public string ReturnUrl { get; set; }
    
}