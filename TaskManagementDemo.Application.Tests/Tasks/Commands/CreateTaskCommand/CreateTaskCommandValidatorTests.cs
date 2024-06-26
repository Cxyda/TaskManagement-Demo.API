using FluentAssertions;
using FluentValidation.TestHelper;
using TaskManagementDemo.Domain.Constants;
using Xunit;
using TaskStatus = TaskManagementDemo.Domain.Constants.TaskStatus;

namespace TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand.Tests;

public class CreateTaskCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        var command = new CreateTaskCommand
        {
            Title = "Test Title",
            Description = "Test Description",
            Status = TaskStatus.Backlog,
            Priority = Priority.High,
            Complexity = Complexity.High
        };

        var validator = new CreateTaskCommandValidator();
        
        var result = validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
    {
        var command = new CreateTaskCommand
        {
            Title = "Te",
            Status = (TaskStatus)255,
            Priority = (Priority)254,
            Complexity = (Complexity)255
        };

        var validator = new CreateTaskCommandValidator();

        var result = validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.Title);
        result.ShouldHaveValidationErrorFor(c => c.Status);
        result.ShouldHaveValidationErrorFor(c => c.Priority);
        result.ShouldHaveValidationErrorFor(c => c.Complexity);
    }
}