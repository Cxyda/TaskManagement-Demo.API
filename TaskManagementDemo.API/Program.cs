
using Microsoft.EntityFrameworkCore;
using TaskManagementDemo.Application.Extensions;
using TaskManagementDemo.Infrastructure.Extensions;
using TaskManagementDemo.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ITaskSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();