using ProjectPortal.Models;

namespace ProjectPortal.Services;

public interface ITaskService
{
    public Task<TaskItem> CreateTask(TaskItem taskItem);
}