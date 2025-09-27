using FluentValidation;

namespace TodoList.Application.TodoItems.Commands.SwitchCompletionTodoItem
{
    public class SwitchCompletionTodoItemCommandValidator : AbstractValidator<SwitchCompletionTodoItemCommand>
    {
        public SwitchCompletionTodoItemCommandValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
