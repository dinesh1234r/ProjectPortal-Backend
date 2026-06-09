using Casbin.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpPost]
    [CasbinAuthorize("Task", "Create")]
    public async Task<IActionResult> CreateTask(
        [FromBody] CreateTaskDto dto)
    {
        var task = await taskService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(CreateTask),
            new { id = task.Id },
            task);
    }

    [HttpPut("{id:int}")]
    [CasbinAuthorize("Task", "Update")]
    public async Task<IActionResult> UpdateTask(
        int id,
        [FromBody] UpdateTaskDto dto)
    {
        var task = await taskService.UpdateAsync(id, dto);

        return Ok(task);
    }

    [HttpDelete("{id:int}")]
    [CasbinAuthorize("Task", "Delete")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await taskService.DeleteAsync(id);

        return NoContent();
    }
}