using Microsoft.AspNetCore.Mvc;
using ProjectPortal.DTOs;

namespace ProjectPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    [HttpPost("createTask")]
    public IActionResult CreateTask(CreateTaskDto createTaskDto)
    {
        return Ok(createTaskDto);
    }

    [HttpPut("updateTask/{id}")]
    public IActionResult UpdateTask(int id,UpdateTaskDto updateTaskDto)
    {
        return Ok(updateTaskDto);   
    }
    
    [HttpDelete("deleteTask/{id}")]
    public IActionResult DeleteTask(int id)
    {
        return Ok(id);
    }
}