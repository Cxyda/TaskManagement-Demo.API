using FluentValidation;
using TaskManagementDemo.Application.Tasks.ValidationRules;

namespace TaskManagementDemo.Application.Tasks.Commands.CreateTaskCommand;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(TaskValidationRuleParameters.EmptyTitleErrorMessage)
            .Length(TaskValidationRuleParameters.MinTitleLength, TaskValidationRuleParameters.MaxTitleLength)
            .WithMessage(TaskValidationRuleParameters.MaxTitleLengthErrorMessage);

        RuleFor(x => x.Description)
            .MaximumLength(TaskValidationRuleParameters.MaxDescriptionLength).WithMessage(TaskValidationRuleParameters.MaxDescriptionLengthErrorMessage);

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidStatusErrorMessage);

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidPriorityErrorMessage);

        RuleFor(x => x.Complexity)
            .IsInEnum().WithMessage(TaskValidationRuleParameters.InvalidComplexityErrorMessage);
    }
}