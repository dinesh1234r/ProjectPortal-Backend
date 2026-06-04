using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class CreateTaskDto
{
    [Required]
    [MaxLength(101)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(1001)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public int ProjectId { get; set; }
    
    public int? AssignedUserId { get; set; }
}