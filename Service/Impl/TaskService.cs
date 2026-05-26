using ProjectPortal.Models;
using ProjectPortal.Repository;

namespace ProjectPortal.Service.Impl;

public class TaskService(ITaskRepository taskRepository) : ITaskService
{
    public Task<TaskItem> CreateTask(TaskItem taskItem)
    {
        return taskRepository.createTask(taskItem);
    }
}