using ProjectPortal.DTOs;
using ProjectPortal.Models;

namespace ProjectPortal.Services;

public interface IProjectService
{
    Task<Project> CreateAsync(CreateProjectDto dto);

    Task<Project> UpdateAsync(
        int id,
        UpdateProjectDto dto);

    Task DeleteAsync(int id);
}