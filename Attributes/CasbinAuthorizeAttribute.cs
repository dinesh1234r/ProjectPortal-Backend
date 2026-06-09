using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectPortal.Services;

namespace ProjectPortal.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class CasbinAuthorizeAttribute(
    string resource,
    string action)
    : Attribute, IAsyncAuthorizationFilter
{
    public Task OnAuthorizationAsync(
        AuthorizationFilterContext context)
    {
        var authService =
            context.HttpContext.RequestServices
                .GetRequiredService<AuthorizationService>();

        var role =
            context.HttpContext.User
                .FindFirst(ClaimTypes.Role)?
                .Value;

        if (string.IsNullOrWhiteSpace(role))
        {
            context.Result = new UnauthorizedResult();
            return Task.CompletedTask;
        }

        var allowed =
            authService.IsAuthorized(
                role,
                resource,
                action);

        if (!allowed)
        {
            context.Result = new ForbidResult();
        }

        return Task.CompletedTask;
    }
}