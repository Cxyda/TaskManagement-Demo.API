namespace TaskManagementDemo.Application.Tasks.ValidationRules
{
    public static class TaskValidationRuleParameters
    {
        public const string EmptyTitleErrorMessage = "Title is required.";
        public static readonly string MaxTitleLengthErrorMessage = $"Title must not exceed {MaxTitleLength} characters.";

        public const int MinTitleLength = 3;
        public const int MaxTitleLength = 200;

        public const int MaxDescriptionLength = 2000;
        public static readonly string MaxDescriptionLengthErrorMessage = $"Description must not exceed {MaxDescriptionLength} characters.";

        public const string InvalidStatusErrorMessage = "Invalid status.";
        public const string InvalidPriorityErrorMessage = "Invalid priority.";
        public const string InvalidComplexityErrorMessage = "Invalid complexity.";

        public const string InvalidSubTaskIdsErrorMessage = $"At least one of the given SubTaskIds is invalid.";
    }
}
