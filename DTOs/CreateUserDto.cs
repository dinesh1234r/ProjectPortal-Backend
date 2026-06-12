using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class CreateUserDto
{
    [Required]
    [MaxLength(101)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(101)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = "Employee";
}