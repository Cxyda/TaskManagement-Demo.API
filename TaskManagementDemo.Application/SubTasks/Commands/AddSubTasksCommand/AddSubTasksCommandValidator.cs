using FluentValidation;
using TaskManagementDemo.Application.Tasks.ValidationRules;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.SubTasks.Commands.AddSubTasksCommand;

public class AddSubTasksCommandValidator : AbstractValidator<AddSubTasksCommand>
{
    public AddSubTasksCommandValidator(ITaskManagementRepository taskManagementRepository)
    {
        RuleFor(x => x.SubTaskIds).Must(taskManagementRepository.ContainsTasksByIdAll)
            .WithMessage(TaskValidationRuleParameters.InvalidSubTaskIdsErrorMessage);
    }
}