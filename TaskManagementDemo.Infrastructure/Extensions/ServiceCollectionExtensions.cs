
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Infrastructure.Authorization;
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

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<TasksUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<TaskManagementDbContext>();

        services.AddScoped<ITaskManagementRepository, TaskManagementRepository>();

        services.AddScoped<ITasksSeeder, TasksSeeder>();
        services.AddScoped<IRolesSeeder, RolesSeeder>();

        services.AddAuthorizationBuilder();
    }
}