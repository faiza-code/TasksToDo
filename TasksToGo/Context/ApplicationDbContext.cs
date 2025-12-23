using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TasksToGo.Models;
using TasksToGo.Models.AuthModel;

namespace TasksToGo.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           // modelBuilder.Entity<TodoTask>()
           //.Ignore(t => t.Category);
        }

        public DbSet<TodoTask> todoTasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<AppUser> appUsers { get; set; }




    }
}
