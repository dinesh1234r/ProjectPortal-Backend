namespace ProjectPortal.Repository;

using ProjectPortal.Models;


public interface IProjectRepository
{
    Task<Project> CreateAsync(Project project);

    Task<Project?> GetByIdAsync(int id);

    Task UpdateAsync(Project project);

    Task DeleteAsync(Project project);
}