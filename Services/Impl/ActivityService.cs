
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;
using ProjectPortal.DTOs;
using ProjectPortal.Models;

namespace ProjectPortal.Services.Impl;

public class ActivityService(AppDbContext context)
    : IActivityService
{
    public async Task LogAsync(
        ClaimsPrincipal actor,
        string action,
        string entityType,
        int? entityId,
        string entityName)
    {
        var actorIdValue =
            actor.FindFirstValue(ClaimTypes.NameIdentifier);

        int? actorUserId = int.TryParse(
            actorIdValue,
            out var parsedId)
            ? parsedId
            : null;

        var actorName =
            actor.FindFirstValue(ClaimTypes.Name)
            ?? actor.FindFirstValue(ClaimTypes.Email)
            ?? actor.Identity?.Name
            ?? "Unknown user";

        var actorRole =
            actor.FindFirstValue(ClaimTypes.Role)
            ?? "Unknown";

        var normalizedAction = action.Trim();
        var normalizedEntityType = entityType.Trim();
        var normalizedEntityName = entityName.Trim();

        var activity = new ActivityLog
        {
            Action = normalizedAction,
            EntityType = normalizedEntityType,
            EntityId = entityId,
            EntityName = normalizedEntityName,
            ActorUserId = actorUserId,
            ActorName = actorName,
            ActorRole = actorRole,
            Description =
                $"{actorName} {normalizedAction.ToLowerInvariant()} " +
                $"{normalizedEntityType.ToLowerInvariant()} " +
                $"\"{normalizedEntityName}\"",
            CreatedAt = DateTime.UtcNow
        };

        context.ActivityLogs.Add(activity);
        await context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<ActivityLogDto>> GetRecentAsync(
        int limit)
    {
        var safeLimit = Math.Clamp(limit, 1, 50);

        return await context.ActivityLogs
            .AsNoTracking()
            .OrderByDescending(activity => activity.CreatedAt)
            .ThenByDescending(activity => activity.Id)
            .Take(safeLimit)
            .Select(activity => new ActivityLogDto
            {
                Id = activity.Id,
                Action = activity.Action,
                EntityType = activity.EntityType,
                EntityId = activity.EntityId,
                EntityName = activity.EntityName,
                Description = activity.Description,
                ActorName = activity.ActorName,
                ActorRole = activity.ActorRole,
                CreatedAt = activity.CreatedAt
            })
            .ToListAsync();
    }
}
