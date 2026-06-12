using AutoMapper;
using ProjectPortal.DTOs;
using ProjectPortal.Models;
using ProjectPortal.Repository;

namespace ProjectPortal.Services.Impl;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper
) : IUserService
{
    public async Task<User> CreateAsync(CreateUserDto dto)
    {
        var user = mapper.Map<User>(dto);

        return await userRepository.CreateAsync(user);
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        mapper.Map(dto, user);

        await userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        await userRepository.DeleteAsync(user);
    }

    public IQueryable<User> GetAll()
    {
        return userRepository.GetAll();
    }
}