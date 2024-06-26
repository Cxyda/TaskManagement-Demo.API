using FluentAssertions;
using TaskManagementDemo.Domain.Constants;
using Xunit;


namespace TaskManagementDemo.Application.Users.Tests;

public class CurrentUserTests
{
    [Theory()]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRole_WithMatchingRule_ShouldReturnTrue(string roleName)
    {
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User]);

        var isInRole = currentUser.IsInRole(roleName);

        isInRole.Should().BeTrue();
    }

    [Fact()]
    public void IsInRole_WithNoMatchingRule_ShouldReturnFalse()
    {
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User]);

        var isInRole = currentUser.IsInRole(UserRoles.Manager);

        isInRole.Should().BeFalse();
    }

    [Fact()]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User]);

        var isInRole = currentUser.IsInRole(UserRoles.Admin.ToUpper());

        isInRole.Should().BeFalse();
    }
}