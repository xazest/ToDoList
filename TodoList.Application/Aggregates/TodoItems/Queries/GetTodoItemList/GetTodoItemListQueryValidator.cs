using FluentValidation;

namespace TodoList.Application.Aggregates.TodoItems.Queries.GetTodoItemList
{
    public class GetTodoItemListQueryValidator : AbstractValidator<GetTodoItemListQuery>
    {
        public GetTodoItemListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }
    }
}
