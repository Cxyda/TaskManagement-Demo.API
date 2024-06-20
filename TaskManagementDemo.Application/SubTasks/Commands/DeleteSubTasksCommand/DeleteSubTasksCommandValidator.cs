using FluentValidation;
using TaskManagementDemo.Application.Tasks.ValidationRules;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.SubTasks.Commands.DeleteSubTasksCommand;

public class DeleteSubTasksCommandValidator : AbstractValidator<DeleteSubTasksCommand>
{
    public DeleteSubTasksCommandValidator(ITaskManagementRepository taskManagementRepository)
    {
        RuleFor(x => x.SubTaskIds).Must(taskManagementRepository.ContainsTasksByIdAll)
            .WithMessage(TaskValidationRuleParameters.InvalidSubTaskIdsErrorMessage);
    }
}
