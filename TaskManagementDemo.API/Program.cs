using AutoMapper;
using Serilog;
using TaskManagementDemo.API.Extensions;
using TaskManagementDemo.API.Middlewares;
using TaskManagementDemo.Application.Dtos;
using TaskManagementDemo.Application.Extensions;
using TaskManagementDemo.Domain.Repositories;
using TaskManagementDemo.Infrastructure.Extensions;
using TaskManagementDemo.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ITaskSeeder>();

await seeder.Seed();

TaskEntityProfile.Init(scope.ServiceProvider.GetService<ITaskManagementRepository>()!);

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();