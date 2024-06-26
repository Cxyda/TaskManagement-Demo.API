
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Infrastructure.Persistence;

internal class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskEntity>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TaskEntity>()
            .HasOne(t => t.ParentTask)
            .WithMany(t => t.SubTasks)
            .HasForeignKey(t => t.ParentTaskId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents circular cascade delete
    }
}