using System.Security.Claims;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL.Helpers;

public static class GraphQLAuthorizationHelper
{
    public static void Authorize(
        ClaimsPrincipal user,
        AuthorizationService authorizationService,
        string resource,
        string action)
    {
        var role =
            user.FindFirst(ClaimTypes.Role)?.Value;

        if (string.IsNullOrWhiteSpace(role))
        {
            throw new GraphQLException(
                "Unauthorized");
        }

        var allowed =
            authorizationService.IsAuthorized(
                role,
                resource,
                action);

        if (!allowed)
        {
            throw new GraphQLException(
                "Forbidden");
        }
    }
}