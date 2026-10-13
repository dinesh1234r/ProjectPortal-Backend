using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ActivityController(
    IActivityService activityService) : ControllerBase
{
    [HttpGet("recent")]
    public async Task<ActionResult<IReadOnlyList<ActivityLogDto>>>
        GetRecent([FromQuery] int limit = 10)
    {
        var activities =
            await activityService.GetRecentAsync(limit);

        return Ok(activities);
    }
}