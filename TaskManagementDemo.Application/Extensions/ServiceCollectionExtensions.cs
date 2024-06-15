﻿
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagementDemo.Application.Extensions;

public static class ServiceCollectionExtensions
{

    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

        services.AddAutoMapper(assembly);

        services.AddHttpContextAccessor();

    }
}