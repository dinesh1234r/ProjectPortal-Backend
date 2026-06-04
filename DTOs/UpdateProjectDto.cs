using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class UpdateProjectDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
}