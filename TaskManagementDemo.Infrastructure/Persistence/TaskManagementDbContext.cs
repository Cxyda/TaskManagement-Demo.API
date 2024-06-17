
using Microsoft.EntityFrameworkCore;
using TaskManagementDemo.Domain.Entities;

namespace TaskManagementDemo.Infrastructure.Persistence;

internal class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : DbContext(options)
{
    internal DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskEntity>()
        .HasMany(e => e.SubTasks)
        .WithOne()
        .HasForeignKey(e => e.Id);
    }
}