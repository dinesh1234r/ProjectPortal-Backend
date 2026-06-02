namespace ProjectPortal.Models;

public class TaskItem
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; } = false;
    
    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;
    
    public int? AssignedUserId { get; set; }
    
    public User? AssignedUser { get; set; }
    
    public DateTime CreatedAt { get; set; }
}