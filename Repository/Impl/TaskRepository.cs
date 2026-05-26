using ProjectPortal.Data;
using ProjectPortal.Models;

namespace ProjectPortal.Repository.Impl;

public class TaskRepository(AppDbContext _context) : ITaskRepository
{
    public async Task<TaskItem> createTask(TaskItem taskItem)
    {
        _context.Add(taskItem);
        _context.SaveChanges();
        return taskItem;
    }
}