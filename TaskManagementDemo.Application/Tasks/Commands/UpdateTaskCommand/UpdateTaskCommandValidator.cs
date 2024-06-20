using FluentValidation;
using TaskManagementDemo.Application.Tasks.ValidationRules;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    private readonly ITaskManagementRepository _taskManagementRepository;

    public UpdateTaskCommandValidator(ITaskManagementRepository taskManagementRepository)
    {
        _taskManagementRepository = taskManagementRepository;

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(TaskValidationRuleParameters.EmptyTitleErrorMessage)
            .MaximumLength(TaskValidationRuleParameters.MaxTitleLength).WithMessage(TaskValidationRuleParameters.MaxTitleLengthErrorMessage);

        RuleFor(x => x.Description)
            .MaximumLength(TaskValidationRuleParameters.MaxDescriptionLength).WithMessage(TaskValidationRuleParameters.MaxDescriptionLengthErrorMessage);

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidStatusErrorMessage);

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidPriorityErrorMessage);

        RuleFor(x => x.Complexity)
            .IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidComplexityErrorMessage);

        RuleFor(x => x.SubTaskIds).Must(CheckExistence).WithMessage(TaskValidationRuleParameters.InvalidSubTaskIdsErrorMessage);
    }

    private bool CheckExistence(List<int> subTaskIds)
    {
        foreach (var subTaskId in subTaskIds)
        {
            var subTask = _taskManagementRepository.GetTaskByIdAsync(subTaskId).Result;
            if (subTask == null)
            {
                return false;
            }
        }

        return true;
    }
}