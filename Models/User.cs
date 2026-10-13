using HotChocolate;

namespace ProjectPortal.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    [GraphQLIgnore]
    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "Employee";

    [GraphQLIgnore]
    public bool MustChangePassword { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TaskItem> TaskItems { get; set; } =
        new List<TaskItem>();
}