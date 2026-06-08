using HotChocolate;
using ProjectPortal.Data;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

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