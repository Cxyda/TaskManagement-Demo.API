using Serilog;
using TaskManagementDemo.API.Extensions;
using TaskManagementDemo.API.Middlewares;
using TaskManagementDemo.Application.Extensions;
using TaskManagementDemo.Domain.Entities;
using TaskManagementDemo.Infrastructure.Extensions;
using TaskManagementDemo.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var tasksSeeder = scope.ServiceProvider.GetRequiredService<ITasksSeeder>();
var rolesSeeder = scope.ServiceProvider.GetRequiredService<IRolesSeeder>();

await tasksSeeder.Seed();
await rolesSeeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
