using System.Security.Claims;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using TaskManagementDemo.Domain.Constants;
using TaskManagementDemo.Domain.Entities;
using Xunit;


namespace TaskManagementDemo.Application.Users.Tests;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        const string eMail = "test@test.com";
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, "1"),
            new(ClaimTypes.Email, eMail),
            new(ClaimTypes.Role, UserRoles.Admin),
            new(ClaimTypes.Role, UserRoles.User),
        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });

        var userContext = new UserContext(httpContextAccessorMock.Object);

        var currentUser = userContext.GetCurrentUser();

        currentUser.Should().NotBeNull();
        currentUser!.Id.Should().Be("1");
        currentUser.Email.Should().Be(eMail);
        currentUser.Roles.Should().ContainInOrder(UserRoles.Admin, UserRoles.User);
    }

    [Fact()]
    public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
    {
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);
        
        var userContext = new UserContext(httpContextAccessorMock.Object);

        Action action = () => userContext.GetCurrentUser();

        action.Should().Throw<InvalidOperationException>().WithMessage("User context is not present");
    }
}