using Microsoft.AspNetCore.Mvc;
using ProjectPortal.Data;
using ProjectPortal.DTOs;
using ProjectPortal.Models;

namespace ProjectPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext context) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = hashedPassword
        };

        context.Users.Add(user);

        await context.SaveChangesAsync();

        return Ok(new
        {
            message = "User registered successfully"
        });
    }
}