using HotChocolate.Authorization;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[Authorize]
[ExtendObjectType("Query")]
public class TaskQuery
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TaskItem> GetAllTasks([Service] ITaskService taskService)
    {
        return taskService.GetAll();
    }
}