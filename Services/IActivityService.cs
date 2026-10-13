using System.Security.Claims;
using ProjectPortal.DTOs;

namespace ProjectPortal.Services;

public interface IActivityService
{
    Task LogAsync(
        ClaimsPrincipal actor,
        string action,
        string entityType,
        int? entityId,
        string entityName);

    Task<IReadOnlyList<ActivityLogDto>> GetRecentAsync(int limit);
}