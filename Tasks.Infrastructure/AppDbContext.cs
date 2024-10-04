using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaskManagement.Domain.Models;
using Task = TaskManagement.Domain.Models.Task;

namespace Tasks.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Task>()
            .HasMany(t => t.Comments)
            .WithOne(c => c.Task)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
