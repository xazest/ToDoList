
using MediatR;

namespace TodoList.Application.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQuery : IRequest<TodoListDto>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
