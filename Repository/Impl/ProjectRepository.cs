using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;
using ProjectPortal.Models;

namespace ProjectPortal.Repository.Impl;

public class ProjectRepository(AppDbContext context)
    : IProjectRepository
{
    public async Task<Project> CreateAsync(Project project)
    {
        await context.Projects.AddAsync(project);

        await context.SaveChangesAsync();

        return project;
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await context.Projects
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Project project)
    {
        context.Projects.Update(project);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Project project)
    {
        context.Projects.Remove(project);

        await context.SaveChangesAsync();
    }
}