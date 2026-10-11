using HotChocolate.Authorization;
using ProjectPortal.DTOs;
using ProjectPortal.Services;

namespace ProjectPortal.GraphQL;

[ExtendObjectType("Query")]
public class AssignableUserQuery
{
    [Authorize(Roles = new[] { "Admin", "Manager" })]
    public IQueryable<AssignableUserDto> GetAssignableUsers(
        [Service] IUserService userService)
    {
        return userService.GetAll()
            .Select(user => new AssignableUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
    }
}