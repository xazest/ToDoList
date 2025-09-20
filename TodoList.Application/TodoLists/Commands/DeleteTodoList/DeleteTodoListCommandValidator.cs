
using FluentValidation;

namespace TodoList.Application.TodoLists.Commands.DeleteTodoList
{
    public class DeleteTodoListCommandValidator : AbstractValidator<DeleteTodoListCommand>
    {
        public DeleteTodoListCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
