using Microsoft.AspNetCore.Identity;

namespace TaskManagementDemo.Domain.Entities;

public class User : IdentityUser
{
    public string? Department { get; set; } = default!;

}