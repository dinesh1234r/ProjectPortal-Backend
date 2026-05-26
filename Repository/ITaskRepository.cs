using ProjectPortal.Models;

namespace ProjectPortal.Repository;

public interface ITaskRepository
{
    public Task<TaskItem> createTask(TaskItem taskItem);
}