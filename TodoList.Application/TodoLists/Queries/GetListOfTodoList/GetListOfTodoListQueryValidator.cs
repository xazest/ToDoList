using FluentValidation;

namespace TodoList.Application.TodoLists.Queries.GetListOfTodoList
{
    public class GetListOfTodoListQueryValidator : AbstractValidator<GetListOfTodoListQuery>
    {
        public GetListOfTodoListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }
    }
}
