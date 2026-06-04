using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;
using ProjectPortal.Models;

namespace ProjectPortal.Repository.Impl;

public class TaskRepository(AppDbContext _context) : ITaskRepository
{
    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        await _context.TaskItems.AddAsync(task);

        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.TaskItems.Update(task);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskItem task)
    {
        _context.TaskItems.Remove(task);

        await _context.SaveChangesAsync();
    }
}