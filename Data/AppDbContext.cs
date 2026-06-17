using System.Data;
using Microsoft.EntityFrameworkCore;
using ProjectPortal.Models;

namespace ProjectPortal.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<TaskItem> TaskItems { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Project> Projects { get; set; }    
    
    public DbSet<CasbinRule> CasbinRules { get; set; }   
}

