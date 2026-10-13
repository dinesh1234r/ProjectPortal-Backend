using HotChocolate.Authorization;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[ExtendObjectType("Query")]
public class TaskQuery
{
    [Authorize]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TaskItem> GetTasks(
        [Service] ITaskService taskService)
    {
        return taskService.GetAll();
    }
}