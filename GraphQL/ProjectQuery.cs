using System.Security.Claims;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Authentication;
using ProjectPortal.GraphQL.Helpers;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[Authorize]
[ExtendObjectType("Query")]
public class ProjectQuery
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects(ClaimsPrincipal user,[Service] AuthorizationService authorizationService,
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