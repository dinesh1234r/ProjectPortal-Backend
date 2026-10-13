using Casbin.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TasksController(
    ITaskService taskService,
    IActivityService activityService) : ControllerBase
{
    [HttpPost]
    [CasbinAuthorize("Task", "Create")]
    public async Task<IActionResult> CreateTask(
        [FromBody] CreateTaskDto dto)
    {
        var task = await taskService.CreateAsync(dto);

        await activityService.LogAsync(
            User, "Created", "Task", task.Id, task.Title);

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

        await activityService.LogAsync(
            User, "Updated", "Task", task.Id, task.Title);

        return Ok(task);
    }

    [HttpDelete("{id:int}")]
    [CasbinAuthorize("Task", "Delete")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await taskService.DeleteAsync(id);

        await activityService.LogAsync(
            User, "Deleted", "Task", id, $"Task #{id}");

        return NoContent();
    }
}