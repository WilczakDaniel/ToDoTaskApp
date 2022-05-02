using Microsoft.EntityFrameworkCore;
using ToDoTaskApp.Entities;

namespace ToDoTaskApp.Database;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    
    public DbSet<ToDoTask> ToDoTasks { get; set; }
    public DbSet<TaskCategory> TaskCategories { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}