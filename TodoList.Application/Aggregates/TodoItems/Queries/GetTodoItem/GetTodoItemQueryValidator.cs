using FluentValidation;

namespace TodoList.Application.Aggregates.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQueryValidator : AbstractValidator<GetTodoItemQuery>
    {
        public GetTodoItemQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
