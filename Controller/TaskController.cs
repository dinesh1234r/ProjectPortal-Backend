using Microsoft.AspNetCore.Mvc;

namespace ProjectPortal.Controller;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}