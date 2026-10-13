using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class UpdateUserDto
{
    [Required]
    [MaxLength(101)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [RegularExpression(
        "^(Manager|Employee)$",
        ErrorMessage = "Role must be either Manager or Employee."
    )]
    public string Role { get; set; } = string.Empty;
}