namespace ProjectPortal.DTOs;

public class UpdateTaskDto
{
    public int Title { get; set; }
    
    public string Description { get; set; } = string.Empty;
    
    public int? AssignedUserId { get; set; }
    
    public bool IsCompleted { get; set; }
}