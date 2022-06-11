using Microsoft.EntityFrameworkCore;
using ToDoTaskApp.Database;
using ToDoTaskApp.Entities;

namespace ToDoTaskApp;

public static class PrepDB
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        void SeedData(AppDbContext context)
        {
            System.Console.WriteLine("Appling migrations..");
            context.Database.Migrate();
            if (!context.Roles.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");
                context.Roles.AddRange(
                    new Role()
                    {
                        Name = "User"
                    },
                    new Role()
                    {
                        Name = "Admin"
                    }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}