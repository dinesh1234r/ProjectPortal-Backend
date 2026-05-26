using ProjectPortal.Models;

namespace ProjectPortal.Service;

public interface ITaskService
{
    public Task<TaskItem> CreateTask(TaskItem taskItem);
}