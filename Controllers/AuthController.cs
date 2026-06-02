using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;
using ProjectPortal.DTOs;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext context,JwtService jwtService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = hashedPassword,
            Role = dto.Role
        };

        context.Users.Add(user);

        await context.SaveChangesAsync();

        return Ok(new
        {
            message = "User registered successfully"
        });
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash
        );

        if (!isPasswordValid)
        {
            return Unauthorized("Invalid email or password");
        }

        var token = jwtService.GenerateToken(user);

        return Ok(new
        {
            token
        });
    }
}