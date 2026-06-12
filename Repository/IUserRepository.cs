using ProjectPortal.Models;

namespace ProjectPortal.Repository;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);

    Task<User?> GetByIdAsync(int id);

    Task UpdateAsync(User user);
    
    Task<User?> GetByEmailAsync(string email);

    Task DeleteAsync(User user);
    
    IQueryable<User> GetAll();
}