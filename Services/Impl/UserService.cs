using System.Security.Cryptography;
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
    public async Task<CreatedUserResponse> CreateAsync(
        CreateUserDto dto)
    {
        var name = dto.Name.Trim();
        var email = dto.Email.Trim().ToLowerInvariant();
        var role = NormalizeRole(dto.Role);

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required.");
        }

        var existingUser = await userRepository.GetByEmailAsync(email);

        if (existingUser != null)
        {
            throw new InvalidOperationException(
                "An account with this email already exists."
            );
        }

        var temporaryPassword = GenerateTemporaryPassword();

        var user = mapper.Map<User>(dto);
        user.Name = name;
        user.Email = email;
        user.Role = role;
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(
            temporaryPassword
        );
        user.MustChangePassword = true;

        var createdUser = await userRepository.CreateAsync(user);

        return new CreatedUserResponse
        {
            Id = createdUser.Id,
            Name = createdUser.Name,
            Email = createdUser.Email,
            Role = createdUser.Role,
            TemporaryPassword = temporaryPassword
        };
    }

    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {
        var name = dto.Name?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required.");
        }

        var role = NormalizeRole(dto.Role);

        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        user.Name = name;
        user.Role = role;

        await userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        await userRepository.DeleteAsync(user);
    }

    public IQueryable<User> GetAll()
    {
        return userRepository.GetAll();
    }

    private static string NormalizeRole(string? role)
    {
        if (string.Equals(
            role?.Trim(),
            "Manager",
            StringComparison.OrdinalIgnoreCase))
        {
            return "Manager";
        }

        if (string.Equals(
            role?.Trim(),
            "Employee",
            StringComparison.OrdinalIgnoreCase))
        {
            return "Employee";
        }

        throw new ArgumentException(
            "Role must be either Manager or Employee."
        );
    }

    private static string GenerateTemporaryPassword()
    {
        var randomPart = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(24)
        )
        .TrimEnd('=')
        .Replace('+', '-')
        .Replace('/', '_');

        return $"{randomPart}aA1!";
    }
}