using AutoMapper;
using ProjectPortal.DTOs;
using ProjectPortal.Models;
using ProjectPortal.Repository;

namespace ProjectPortal.Services.Impl;

public class ProjectService(
    IProjectRepository projectRepository,
    IMapper mapper)
    : IProjectService
{
    public async Task<Project> CreateAsync(
        CreateProjectDto dto)
    {
        var project = mapper.Map<Project>(dto);

        return await projectRepository.CreateAsync(project);
    }

    public async Task<Project> UpdateAsync(
        int id,
        UpdateProjectDto dto)
    {
        var project = await projectRepository.GetByIdAsync(id);

        if (project is null)
        {
            throw new Exception($"Project with id {id} not found");
        }

        mapper.Map(dto, project);

        await projectRepository.UpdateAsync(project);

        return project;
    }

    public async Task DeleteAsync(int id)
    {
        var project = await projectRepository.GetByIdAsync(id);

        if (project is null)
        {
            throw new Exception($"Project with id {id} not found");
        }

        await projectRepository.DeleteAsync(project);
    }
}