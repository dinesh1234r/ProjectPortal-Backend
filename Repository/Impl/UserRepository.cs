using Microsoft.EntityFrameworkCore;
using ProjectPortal.Data;
using ProjectPortal.Models;

namespace ProjectPortal.Repository.Impl;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> CreateAsync(User user)
    {
        await context.Users.AddAsync(user);

        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        context.Users.Remove(user);

        await context.SaveChangesAsync();
    }

    public IQueryable<User> GetAll()
    {
        return context.Users.AsNoTracking();
    }
}