using HotChocolate.Authorization;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[Authorize]
[ExtendObjectType("Query")]
public class UserQuery
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers(
        [Service] IUserService userService)
    {
        return userService.GetAll();
    }
}