using FluentValidation;

namespace TodoList.Application.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQueryValidator : AbstractValidator<GetTodoListQuery>
    {
        public GetTodoListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
