using Microsoft.AspNetCore.Identity;
using TaskManagementDemo.Domain.Constants;
using TaskManagementDemo.Infrastructure.Persistence;

namespace TaskManagementDemo.Infrastructure.Seeders;

public interface IRolesSeeder : IDatabaseSeeder
{
}
internal class RolesSeeder(TaskManagementDbContext dbContext) : IRolesSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
        [
            new IdentityRole(UserRoles.User)
            {
                NormalizedName = UserRoles.User.ToUpper()
            },
            new IdentityRole(UserRoles.Manager)
            {
                NormalizedName = UserRoles.Manager.ToUpper()
            },
            new IdentityRole(UserRoles.Admin)
            {
                NormalizedName = UserRoles.Admin.ToUpper()
            }
        ];

        return roles;
    }
}