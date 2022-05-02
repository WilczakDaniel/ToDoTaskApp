using Microsoft.EntityFrameworkCore;
using ToDoTaskApp.Entities;

namespace ToDoTaskApp.Database;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    
    DbSet<ToDoTask> ToDoTasks { get; set; }
    DbSet<TaskCategory> TaskCategories { get; set; }
    DbSet<Priority> Priorities { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
}