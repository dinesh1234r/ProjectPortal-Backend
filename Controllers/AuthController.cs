using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    AppDbContext context,
    JwtService jwtService
) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register()
    {
        return StatusCode(
            StatusCodes.Status403Forbidden,
            new
            {
                message = "Public registration is disabled. Contact your administrator."
            }
        );
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email);

        if (user == null ||
            !BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash))
        {
            return Unauthorized("Invalid email or password");
        }

        var token = jwtService.GenerateToken(user);

        return Ok(new
        {
            token,
            mustChangePassword = user.MustChangePassword
        });
    }

    [Authorize]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(
        ChangePasswordDto dto)
    {
        var userIdValue = User.FindFirstValue(
            ClaimTypes.NameIdentifier
        );

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized();
        }

        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            return Unauthorized();
        }

        if (!BCrypt.Net.BCrypt.Verify(
            dto.CurrentPassword,
            user.PasswordHash))
        {
            return BadRequest(new
            {
                message = "Current password is incorrect."
            });
        }

        if (dto.CurrentPassword == dto.NewPassword)
        {
            return BadRequest(new
            {
                message = "Your new password must be different from your current password."
            });
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(
            dto.NewPassword
        );
        user.MustChangePassword = false;

        await context.SaveChangesAsync();

        return Ok(new
        {
            message = "Password changed successfully. Please log in again."
        });
    }
}