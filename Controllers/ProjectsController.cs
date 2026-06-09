using Casbin.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpPost]
    [CasbinAuthorize("Project", "Create")]
    public async Task<IActionResult> CreateProject(
        [FromBody] CreateProjectDto dto)
    {
        var project = await projectService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(CreateProject),
            new { id = project.Id },
            project);
    }

    [HttpPut("{id:int}")]
    [CasbinAuthorize("Project", "Update")]
    public async Task<IActionResult> UpdateProject(
        int id,
        [FromBody] UpdateProjectDto dto)
    {
        var project = await projectService.UpdateAsync(id, dto);

        return Ok(project);
    }

    [HttpDelete("{id:int}")]
    [CasbinAuthorize("Project", "Delete")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        await projectService.DeleteAsync(id);

        return NoContent();
    }
}