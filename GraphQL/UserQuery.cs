using HotChocolate.Authorization;
using ProjectPortal.Models;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[ExtendObjectType("Query")]
public class UserQuery
{
    [Authorize(Roles = new[] { "Admin" })]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers(
        [Service] IUserService userService)
    {
        return userService.GetAll();
    }
}