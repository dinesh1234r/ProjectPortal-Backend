using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(101)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(101)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}