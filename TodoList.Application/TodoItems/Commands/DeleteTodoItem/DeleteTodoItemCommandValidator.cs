
using FluentValidation;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        public DeleteTodoItemCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
