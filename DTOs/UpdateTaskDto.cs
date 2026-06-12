using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.DTOs;

public class UpdateTaskDto
{
    [Required]
    [MaxLength(101)]
    public string Title { get; set; }
    
    [MaxLength(501)]
    public string Description { get; set; } = string.Empty;
    
    public int? AssignedUserId { get; set; }
    
    public bool IsCompleted { get; set; }
}