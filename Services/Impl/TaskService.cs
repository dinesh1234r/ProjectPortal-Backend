using AutoMapper;
using ProjectPortal.DTOs;
using ProjectPortal.Models;
using ProjectPortal.Repository;

namespace ProjectPortal.Services.Impl;

public class TaskService(ITaskRepository taskRepository,IMapper mapper) : ITaskService
{
    public async Task<TaskItem> CreateAsync(
        CreateTaskDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new Exception(
                "Task title is required");
        }

        var task = mapper.Map<TaskItem>(dto);

        return await taskRepository.CreateAsync(task);
    }
    
    public async Task<TaskItem> UpdateAsync(
        int id,
        UpdateTaskDto dto)
    {
        var task = await taskRepository.GetByIdAsync(id);

        if (task == null)
        {
            throw new Exception(
                "Task not found");
        }

        mapper.Map(dto, task);

        await taskRepository.UpdateAsync(task);

        return task;
    }

    public async Task DeleteAsync(int id)
    {
        var task = await taskRepository.GetByIdAsync(id);

        if (task == null)
        {
            throw new Exception(
                "Task not found");
        }

        await taskRepository.DeleteAsync(task);
    }

}