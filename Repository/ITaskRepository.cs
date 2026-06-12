using ProjectPortal.Models;

namespace ProjectPortal.Repository;

public interface ITaskRepository
{
    Task<TaskItem> CreateAsync(TaskItem task);

    Task<TaskItem?> GetByIdAsync(int id);

    Task UpdateAsync(TaskItem task);

    Task DeleteAsync(TaskItem task);
    
    IQueryable<TaskItem> GetAll();
}