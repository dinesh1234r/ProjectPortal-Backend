namespace ProjectPortal.DTOs;

public class CreatedUserResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string TemporaryPassword { get; set; } = string.Empty;
}