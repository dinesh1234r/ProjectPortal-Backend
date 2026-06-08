using HotChocolate.Authorization;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[Authorize]
public class ProjectQuery
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProject([Service] IProjectService projectService)
    {
        return projectService.GetAll();
    }
}