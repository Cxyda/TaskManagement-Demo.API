using TaskManagementDemo.API.Middlewares;

namespace TaskManagementDemo.API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();

            builder.Services.AddControllers();

            builder.Services.AddScoped<ErrorHandlingMiddleware>();
        }
    }
}
