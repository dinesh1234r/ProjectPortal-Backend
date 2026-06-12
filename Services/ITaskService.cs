using ProjectPortal.DTOs;
using ProjectPortal.Models;

namespace ProjectPortal.Services;

public interface ITaskService
{
    Task<TaskItem> CreateAsync(CreateTaskDto dto);

    Task<TaskItem> UpdateAsync(
        int id,
        UpdateTaskDto dto);

    Task DeleteAsync(int id);
    
    IQueryable<TaskItem> GetAll();
}