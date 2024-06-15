
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Infrastructure.Persistence;
using TaskManagementDemo.Infrastructure.Repositories;
using TaskManagementDemo.Infrastructure.Seeders;

namespace TaskManagementDemo.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TaskManagementDb");
        services.AddDbContext<TaskManagementDbContext>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());


        services.AddScoped<ITaskManagementRepository, TaskManagementRepository>();
        services.AddScoped<ITaskSeeder, TaskSeeder>();

    }
}