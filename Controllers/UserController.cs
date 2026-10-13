using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPortal.Attributes;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController(
    IUserService userService
) : ControllerBase
{
    [HttpPost]
    [CasbinAuthorize("User", "Create")]
    public async Task<IActionResult> CreateUser(
        CreateUserDto dto)
    {
        try
        {
            var result = await userService.CreateAsync(dto);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [CasbinAuthorize("User", "Update")]
    public async Task<IActionResult> UpdateUser(
        int id,
        UpdateUserDto dto)
    {
        await userService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [CasbinAuthorize("User", "Delete")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }
}