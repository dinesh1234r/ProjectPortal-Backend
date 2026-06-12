using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class UpdateUserDto
{
    [Required]
    [MaxLength(101)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = string.Empty;
}