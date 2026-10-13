using System.Security.Claims;
using HotChocolate.Authorization;
using ProjectPortal.GraphQL.Helpers;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[ExtendObjectType("Query")]
public class ProjectQuery
{
    [Authorize]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects(
        ClaimsPrincipal user,
        [Service] AuthorizationService authorizationService,
        [Service] IProjectService projectService)
    {
        GraphQLAuthorizationHelper.Authorize(
            user,
            authorizationService,
            "Project",
            "Read");

        return projectService.GetAll();
    }
}