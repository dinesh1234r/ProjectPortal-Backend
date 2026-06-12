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
        var user =
            await userService.CreateAsync(dto);

        return Ok(user);
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
    public async Task<IActionResult> DeleteUser(
        int id)
    {
        await userService.DeleteAsync(id);

        return NoContent();
    }
}