using FluentValidation;
using TaskManagementDemo.Application.Tasks.ValidationRules;
using TaskManagementDemo.Domain.Repositories;

namespace TaskManagementDemo.Application.Tasks.Commands.UpdateTaskCommand;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(TaskValidationRuleParameters.EmptyTitleErrorMessage)
            .MaximumLength(TaskValidationRuleParameters.MaxTitleLength).WithMessage(TaskValidationRuleParameters.MaxTitleLengthErrorMessage);

        RuleFor(x => x.Description)
            .NotEmpty().MaximumLength(TaskValidationRuleParameters.MaxDescriptionLength).WithMessage(TaskValidationRuleParameters.MaxDescriptionLengthErrorMessage);

        RuleFor(x => x.Status)
            .NotEmpty().IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidStatusErrorMessage);

        RuleFor(x => x.Priority)
            .NotEmpty().IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidPriorityErrorMessage);

        RuleFor(x => x.Complexity)
            .NotEmpty().IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidComplexityErrorMessage);
    }
}