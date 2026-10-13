namespace ProjectPortal.DTOs;

public class ActivityLogDto
{
    public int Id { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityType { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    public string EntityName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ActorName { get; set; } = string.Empty;

    public string ActorRole { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}