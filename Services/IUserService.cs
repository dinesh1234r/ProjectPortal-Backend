using ProjectPortal.DTOs;
using ProjectPortal.Models;

namespace ProjectPortal.Services;

public interface IUserService
{
    Task<CreatedUserResponse> CreateAsync(CreateUserDto dto);

    Task UpdateAsync(int id, UpdateUserDto dto);

    Task DeleteAsync(int id);

    IQueryable<User> GetAll();
}