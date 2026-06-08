using HotChocolate;
using ProjectPortal.Data;
using ProjectPortal.Models;

namespace ProjectPortal.GraphQL;

public class ProjectQuery
{
    public IQueryable<Project> GetProject([Service] AppDbContext context)
    {
        return context.Projects;
    }
}