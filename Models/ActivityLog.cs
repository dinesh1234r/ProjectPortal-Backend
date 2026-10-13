using System.ComponentModel.DataAnnotations;

namespace ProjectPortal.Models;

public class ActivityLog
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Action { get; set; } = string.Empty;

    [Required]
    [MaxLength(40)]
    public string EntityType { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    [Required]
    [MaxLength(200)]
    public string EntityName { get; set; } = string.Empty;

    [Required]
    [MaxLength(600)]
    public string Description { get; set; } = string.Empty;

    public int? ActorUserId { get; set; }

    [Required]
    [MaxLength(200)]
    public string ActorName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string ActorRole { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}